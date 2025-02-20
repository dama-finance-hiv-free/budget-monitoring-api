using System;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Core;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Infrastructure.Persistence.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RunnerPersistence : RepositoryBase<Runner>, IRunnerPersistence
{
    public RunnerPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {

    }

    public async Task<Runner[]> GetAllRunnersByRegionAsync(string region)
    {
        var serverStatusPersistence = new ServerStatusPersistence(DatabaseFactory);
        var serverStatusCopYears = await serverStatusPersistence.GetServerStatusCopYearsAsync(region);

        if (serverStatusCopYears is null) throw new ArgumentNullException(region);
        
        var regionRunners = await DbSet.Where(x => x.Region == region && serverStatusCopYears.Contains(x.CopYear))
            .ToArrayAsync();
        
        return regionRunners;
    }

    public async Task<Runner> GetActiveRunnerAsync(string region, string project) =>
        await DbSet.FirstOrDefaultAsync(x => x.Region == region && x.Project == project);

    public async Task<Runner[]> GetAllRunnersByBranchAsync(string tenant, string branch)
    {
        var branchPersistence = new BranchPersistence(DatabaseFactory);
        var br = await branchPersistence.GetBranchAsync(tenant, branch);
        if (br is null) throw new ArgumentNullException(branch);

        var region = br.Region;

        return await GetAllRunnersByRegionAsync(region);
    }

    public async Task<RepositoryActionResult<Runner>> AddAsync(string tenant, string runnerPeriodCode, string region, string projectCode)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            if(runnerPeriodCode == null)
                throw new ArgumentNullException(nameof(runnerPeriodCode));

            if (region == null)
                throw new ArgumentNullException(nameof(region));

            var currentRunner = await DbSet.FirstOrDefaultAsync(x => x.Region == region && x.Project == projectCode);

            if (currentRunner == null)
                throw new Exception("current runner does not exist");

            //archive runner
            var runnerHistory = CreateRunnerHistory(currentRunner);
            var runnerHistoryPersistence = new RunnerHistoryPersistence(DatabaseFactory);

            var runnerHistoryResult = await runnerHistoryPersistence.AddAsync(runnerHistory);
            if (runnerHistoryResult.Status != RepositoryActionStatus.Created)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<Runner>(null, RepositoryActionStatus.Error);
            }

            var runnerComponentPersistence = new RunnerComponentPersistence(DatabaseFactory);
            var currentRunnerComponent = await runnerComponentPersistence.GetAsync(currentRunner.Tenant, currentRunner.Code);

            var runnerComponentHistory = CreateRunnerComponentHistory(currentRunnerComponent);
            var runnerComponentHistoryPersistence = new RunnerComponentHistoryPersistence(DatabaseFactory);
            
            //archive runner component
            var runnerComponentHistoryResult = await runnerComponentHistoryPersistence.AddAsync(runnerComponentHistory);
            if (runnerComponentHistoryResult.Status != RepositoryActionStatus.Created)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<Runner>(null, RepositoryActionStatus.Error);
            }

            //delete runner
            //var runnerResult = await DeleteAsync(currentRunner);
            Context.Entry(currentRunner).State = EntityState.Deleted;
            var result = await SaveChangesAsync();
            if (result <= 0)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<Runner>(null, RepositoryActionStatus.Error);
            }

            //delete  runner component
            var runnerComponentResult = await runnerComponentPersistence.DeleteAsync(currentRunnerComponent);
            if (runnerComponentResult.Status != RepositoryActionStatus.Deleted)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<Runner>(null, RepositoryActionStatus.Error);
            }

            //create new runner
            var runnerPeriodPersistence = new RunnerPeriodPersistence(DatabaseFactory);
            
            var runnerPeriod = await runnerPeriodPersistence.GetAsync(tenant, runnerPeriodCode);
            if (runnerPeriod == null)
                throw new Exception("invalid runner period defined");

            var runner = CreateRunner(runnerPeriod);
            runner.Code = $"{region}{runnerPeriod.Code}";
            runner.MilestoneProjection = $"{region}{runnerPeriod.MilestoneProjection}";
            runner.Region = region;
            runner.Project = projectCode;

            var runnerResult = await AddAsync(runner);
            if (runnerResult.Status != RepositoryActionStatus.Created)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<Runner>(null, RepositoryActionStatus.Error);
            }


            //create new runner component
            var runnerPeriodComponentPersistence = new RunnerPeriodComponentPersistence(DatabaseFactory);

            var runnerPeriodComponent = await runnerPeriodComponentPersistence.GetAsync(tenant, runnerPeriodCode);
            if (runnerPeriodComponent == null)
            {
                throw new Exception("invalid runner period defined");
            }

            var runnerComponent = CreateRunnerComponent(runnerPeriodComponent);
            runnerComponent.Runner = runner.Code;
            runnerComponent.Project = runner.Project;

            runnerComponentResult = await runnerComponentPersistence.AddAsync(runnerComponent);
            if (runnerComponentResult.Status != RepositoryActionStatus.Created)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<Runner>(null, RepositoryActionStatus.Error);
            }
            
            //post activities
            var activityPersistence = new ActivityPersistence(DatabaseFactory);

            var activities = await activityPersistence.GetManyAsync(x => x.Region == region && x.ActivityType == "01" && x.Project == projectCode);
            if (activities.Any())
            {
                var activityHistory = activities.Select(CreateActivityHistory);
                var activityHistoryPersistence = new ActivityHistoryPersistence(DatabaseFactory);
                var activityHistoryResult = await activityHistoryPersistence.AddManyAsync(activityHistory);
                if (activityHistoryResult.Status != RepositoryActionStatus.Created)
                {
                    await tx.RollbackAsync();
                    return new RepositoryActionResult<Runner>(null, RepositoryActionStatus.Error);
                }

                var activityResult =
                    await activityPersistence.DeleteManyAsync(x => x.Region == region && x.ActivityType == "01" && x.Project == projectCode);
                if (activityResult.Status != RepositoryActionStatus.Deleted)
                {
                    await tx.RollbackAsync();
                    return new RepositoryActionResult<Runner>(null, RepositoryActionStatus.Error);
                }
            }
            
            //commit and return result
            await tx.CommitAsync();
            return new RepositoryActionResult<Runner>(runner, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Runner>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<RepositoryActionResult<Runner>> ArchiveAsync(Runner entity)
    {
        entity.Status = "63";
        return await EditAsync(entity);
    }

    public async Task<Runner[]> GetRunnersAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    public async Task<Runner> GetRunnerOrHistoryAsync(string tenant, string code)
    {
        var runner = await GetAsync(tenant, code);
        if (runner != null)
            return runner;

        var runnerHistory =
            await Context.RunnerHistorySet.FirstOrDefaultAsync(x => x.Tenant == tenant && x.Code == code);

        if (runnerHistory != null)
            return CreateRunner(runnerHistory);

        return null;
    }

    private static RunnerHistory CreateRunnerHistory(Runner runner) =>
        JsonPropertyMapper<Runner, RunnerHistory>.PropertyMap(runner);

    private static Runner CreateRunner(RunnerHistory runner) =>
        JsonPropertyMapper<RunnerHistory, Runner>.PropertyMap(runner);

    private static Runner CreateRunner(RunnerPeriod runnerPeriod) =>
        JsonPropertyMapper<RunnerPeriod, Runner>.PropertyMap(runnerPeriod);

    private static RunnerComponent CreateRunnerComponent(RunnerPeriodComponent runnerPeriodComponent) =>
        JsonPropertyMapper<RunnerPeriodComponent, RunnerComponent>.PropertyMap(runnerPeriodComponent);

    private static ActivityHistory CreateActivityHistory(Activity activity) =>
        JsonPropertyMapper<Activity, ActivityHistory>.PropertyMap(activity);

    private static RunnerComponentHistory CreateRunnerComponentHistory(RunnerComponent runnerComponent) =>
        JsonPropertyMapper<RunnerComponent, RunnerComponentHistory>.PropertyMap(runnerComponent);

    protected override async Task<Runner> ItemToGetAsync(string tenant, string runner) =>
        await GetFirstOrDefaultAsync(x => x.Code == runner);

    protected override async Task<Runner> ItemToGetAsync(Runner runner) =>
        await GetFirstOrDefaultAsync(x => x.Code == runner.Code);
}