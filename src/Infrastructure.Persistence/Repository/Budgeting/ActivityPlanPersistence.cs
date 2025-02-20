using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class ActivityPlanPersistence : RepositoryBase<ActivityPlan>, IActivityPlanPersistence
{
    public ActivityPlanPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<ActivityPlan>> AddAsync(ActivityPlan entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastActivityPlan = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastActivityPlan == null
                ? "1".ToTwoChar()
                : (lastActivityPlan.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<ActivityPlan>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<ActivityPlan>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<ActivityPlan>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<ActivityPlan[]> GetActivityPlansAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    public async Task<ActivityPlan[]> GetActivityPlansAsync(string tenant, string copYear, string component, string project)
    {
        var componentActivityPersistence = new ComponentActivityPersistence(DatabaseFactory);
        //var activityCodes = await componentActivityPersistence.GetComponentActivityCodesAsync(tenant, copYear, component);

        //ActivityPlan[] activities;

        //if (!string.IsNullOrEmpty(project))
        //    activities = await GetManyAsync(x =>
        //        x.Tenant == tenant && x.Project == project && activityCodes.Contains(x.Code));
        //else
        //    activities = await GetManyAsync(x => x.Tenant == tenant && activityCodes.Contains(x.Code));

        //return activities.ToArray();

        ActivityPlan[] activities;

        if (!string.IsNullOrEmpty(project))
            activities = await GetManyAsync(x =>
                x.Tenant == tenant && x.Project == project);
        else
            activities = await GetManyAsync(x => x.Tenant == tenant);

        return activities.ToArray();

    }

    public async Task<ActivityPlan[]> GetSurgeActivityPlansAsync(string tenant, string copYear, string component, string project)
    {
        var componentActivityPersistence = new ComponentActivityPersistence(DatabaseFactory);
        var activityCodes = await componentActivityPersistence.GetComponentActivityCodesAsync(tenant, copYear, component);

        var surgeActivityPersistence = new SurgeActivityPersistence(DatabaseFactory);
        var surgeActivityCodes = await surgeActivityPersistence.GetSurgeActivityCodesAsync();

        ActivityPlan[] activities;

        if (!string.IsNullOrEmpty(project))
            activities = await GetManyAsync(x =>
                x.Tenant == tenant && x.Project == project && activityCodes.Contains(x.Code));
        else
            activities = await GetManyAsync(x => x.Tenant == tenant && activityCodes.Contains(x.Code));

        var surgeActivities = activities.Where(x => surgeActivityCodes.Contains(x.Code)).ToArray();

        return surgeActivities.ToArray();
    }

    protected override async Task<ActivityPlan> ItemToGetAsync(string tenant, string activityPlan) =>
        await GetFirstOrDefaultAsync(x => x.Code == activityPlan);

    protected override async Task<ActivityPlan> ItemToGetAsync(ActivityPlan activityPlan) =>
        await GetFirstOrDefaultAsync(x => x.Code == activityPlan.Code);
}