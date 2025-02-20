using System;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class MilestonePersistence : RepositoryBase<Milestone>, IMilestonePersistence
{
    public MilestonePersistence(IDatabaseFactory databaseFactory, ISitePersistence sitePersistence, IActivityPlanPersistence activityPlanPersistence, IInterventionPersistence interventionPersistence, IBudgetCodePersistence budgetCodePersistence)
        : base(databaseFactory)
    {
        _interventionPersistence = interventionPersistence;
        _budgetCodePersistence = budgetCodePersistence;
        _sitePersistence = sitePersistence;
        _activityPlanPersistence = activityPlanPersistence;
    }

    private readonly IInterventionPersistence _interventionPersistence;
    private readonly IBudgetCodePersistence _budgetCodePersistence;
    private readonly ISitePersistence _sitePersistence;
    private readonly IActivityPlanPersistence _activityPlanPersistence;

    public async Task<RepositoryActionResult<Milestone>> UpdateProjectionAsync(Milestone milestone)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var existingMilestone = await DbSet.AsNoTracking().FirstOrDefaultAsync(x =>
                x.Activity == milestone.Activity && x.Runner == milestone.Runner && x.Site == milestone.Site &&
                x.Tenant == milestone.Tenant && x.Project == milestone.Project);

            if (existingMilestone != null)
            {
                var clearResult = await DeleteAsync(existingMilestone);
                if (clearResult.Status != RepositoryActionStatus.Deleted)
                {
                    await tx.RollbackAsync();
                    return new RepositoryActionResult<Milestone>(null, RepositoryActionStatus.Error);
                }
            }

            var result = await AddAsync(milestone);
            if (result.Status != RepositoryActionStatus.Created)
            {
                return new RepositoryActionResult<Milestone>(milestone, RepositoryActionStatus.Error);
            }
            await tx.CommitAsync();
            return new RepositoryActionResult<Milestone>(milestone, RepositoryActionStatus.Okay);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Milestone>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<RepositoryActionResult<Milestone>> UpdateAchievementAsync(Milestone milestone)
    {
        try
        {
            var existingMilestone = await DbSet.AsNoTracking().FirstOrDefaultAsync(x =>
                x.Activity == milestone.Activity && x.Runner == milestone.Runner && x.Site == milestone.Site &&
                x.Tenant == milestone.Tenant && x.Project == milestone.Project);

            if (existingMilestone == null)
            {
                return new RepositoryActionResult<Milestone>(null, RepositoryActionStatus.Error);
            }

            Context.Entry(existingMilestone).State = EntityState.Detached;
            existingMilestone.Achievement = milestone.Achievement;
            DbSet.Attach(existingMilestone);
            Context.Entry(existingMilestone).State = EntityState.Modified;
            var result = await SaveChangesAsync();

            return result == 0
                ? new RepositoryActionResult<Milestone>(null, RepositoryActionStatus.Error)
                : new RepositoryActionResult<Milestone>(milestone, RepositoryActionStatus.Okay);
        }
        catch (Exception ex)
        {
            return new RepositoryActionResult<Milestone>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<Milestone[]> GetMilestonesAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    public async Task<MilestoneDashboardVm[]> GetMilestoneDashboardBySite(MilestoneDasboardOptions Options)
    {
        try
        {

            var milestones = await DbSet.Where(x =>
            x.Runner == Options.Runner &&
            x.Site == Options.Site).ToArrayAsync();


            var milestoneDashboards = milestones.Select(x =>
            {
                var activity = GetActivityPlanDescription(x.Activity).Result;
                var site = GetSiteDescription(x.Site).Result;
                var intervention = GetIntervention(x.Activity).Result;
                return new MilestoneDashboardVm
                {
                    Tenant = x.Tenant,
                    Runner = x.Runner,
                    Region = x.Region,
                    Project = x.Project,
                    Activity = x.Activity,
                    ActivityPlanDescription = activity.Description,
                    Site = x.Site,
                    SiteName = site.Description,
                    BudgetNote = x.BudgetNote,
                    Target = x.Target,
                    Achievement = x.Achievement,
                    Budget = x.Budget,
                    InterventionCode = intervention.Code,
                    InterventionName = intervention.Description
                };
            }).ToArray();
     
            return milestoneDashboards;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<ActivityPlan> GetActivityPlanDescription(string code)
    {
        return await _activityPlanPersistence.GetFirstOrDefaultAsync(x => x.Code == code);
    }
    public async Task<Site> GetSiteDescription(string code)
    {
        return await _sitePersistence.GetFirstOrDefaultAsync(x => x.Code == code);
    }

    public async Task<Intervention> GetIntervention(string code)
    {
        var activityPlan = await _activityPlanPersistence.GetFirstOrDefaultAsync(x => x.Code == code);
        return await _interventionPersistence.GetFirstOrDefaultAsync(x => x.Code == activityPlan.Intervention);
    }

    protected override async Task<Milestone> ItemToGetAsync(Milestone milestone) =>
        await GetFirstOrDefaultAsync(x =>
            x.Tenant == milestone.Tenant && x.Runner == milestone.Runner && x.Activity == milestone.Activity &&
            x.Site == milestone.Site);
}