using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Core;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RunnerPeriodPersistence : RepositoryBase<RunnerPeriod>, IRunnerPeriodPersistence
{
    public RunnerPeriodPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<RepositoryActionResult<RunnerPeriod>> ActivateAsync(RunnerPeriod runnerPeriod) =>
        await EditAsync(runnerPeriod);

    public async Task<RepositoryActionResult<RunnerPeriod>> ArchiveAsync(RunnerPeriod runnerPeriod)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var existingRunnerPeriod = await GetAsync(runnerPeriod.Tenant, runnerPeriod.Code);

            if (existingRunnerPeriod == null)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<RunnerPeriod>(runnerPeriod, RepositoryActionStatus.NotFound);
            }

            var runnerPeriodHistory = CreateRunnerPeriodHistory(existingRunnerPeriod);

            Context.RunnerPeriodHistorySet.Add(runnerPeriodHistory);

            var result = await SaveChangesAsync();

            if (result == 0)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<RunnerPeriod>(runnerPeriod, RepositoryActionStatus.NothingModified);
            }

            var deleteResult = await DeleteAsync(runnerPeriod);
            if (deleteResult.Status != RepositoryActionStatus.Deleted)
            {
                await tx.RollbackAsync();
                return deleteResult;
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<RunnerPeriod>(runnerPeriod, RepositoryActionStatus.Okay);
        }
        catch (Exception)
        {
            await tx.RollbackAsync();
            throw;
        }
    }

    public override async Task<RepositoryActionResult<RunnerPeriod>> AddAsync(RunnerPeriod runnerPeriod)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var reference =
                $"{runnerPeriod.StartDate.Month.ToString().ToTwoChar()}{runnerPeriod.StartDate.Year.ToString().Substring(2, 2)}";

            var lastRunnerPeriod = DbSet.Where(x => x.Code.Substring(0, 4) == reference).OrderByDescending(x => x.Code)
                .ToArray().FirstOrDefault();

            var serial = lastRunnerPeriod == null
                ? "1".ToTwoChar()
                : (lastRunnerPeriod.Code.Substring(4,2).ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();

            runnerPeriod.Code = $"{reference}{serial}";

            var runnerPeriodComponent = new RunnerPeriodComponent
            {
                Tenant = runnerPeriod.Tenant,
                RunnerPeriod = runnerPeriod.Code,
                Project = "01",
                Component = runnerPeriod.Component,
                CreatedOn = DateTime.Now.ToUtcDate()
            };
            var runnerPeriodComponentPersistence = new RunnerPeriodComponentPersistence(DatabaseFactory);

            var runnerPeriodResult = await runnerPeriodComponentPersistence.AddAsync(runnerPeriodComponent);
            if (runnerPeriodResult.Status != RepositoryActionStatus.Created)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<RunnerPeriod>(runnerPeriod, runnerPeriodResult.Status);
            }


            DbSet.Add(runnerPeriod);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<RunnerPeriod>(runnerPeriod, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<RunnerPeriod>(runnerPeriod, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<RunnerPeriod>(null, RepositoryActionStatus.Error, ex);
        }
    }

    private static RunnerPeriodHistory CreateRunnerPeriodHistory(RunnerPeriod temporalJournal) =>
        PropertyMapper.PropertyMap(temporalJournal, new RunnerPeriodHistory());

    public async Task<RunnerPeriod[]> GetRunnerPeriodsAsync(string tenant) =>
        await DbSet.AsNoTracking().Where(x => x.Tenant == tenant).OrderBy(x => x.Code).ToArrayAsync();

    public async Task<string[]> GetRunnerPeriodHistoryCodesAsync(string tenant, string region, string copYear, string project)
    {
        try
        {
            const string sql = @"select distinct period from 
(
select substring(runner from 3 for 6) as period from budgeting.activity where region = @region and project = @project union all
select substring(runner from 3 for 6) as period from budgeting.activity_history where region = @region and project = @project union all
select substring(code from 3 for 6) as period from budgeting.runner where region = @region and project = @project
) as runnerperiod order by 1;"
            ;

            var queryParams = new
            {
                tenant,
                region,
                project
            };

            var runnerPeriodCodes = await Db.QueryAsync<string>(sql, queryParams);

            return runnerPeriodCodes as string[] ?? runnerPeriodCodes.ToArray();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
        

    protected override async Task<RunnerPeriod> ItemToGetAsync(string tenant, string runnerPeriod) =>
        await GetFirstOrDefaultAsync(x => x.Tenant == tenant && x.Code == runnerPeriod);
}