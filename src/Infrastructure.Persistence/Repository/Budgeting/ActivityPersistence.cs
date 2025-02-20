using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Infrastructure.Persistence.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class ActivityPersistence : RepositoryBase<Activity>, IActivityPersistence
{
    public ActivityPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Activity>> AddAsync(Activity entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var (batch, serial) = await GetTransactionBatchSerialAsync(entity);

            entity.Batch = batch;
            entity.BatchLine = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Activity>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Activity>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Activity>(null, RepositoryActionStatus.Error, ex);
        }
    }

    private async Task<(string batch, string serial)> GetTransactionBatchSerialAsync(ActivityBase activity)
    {
        string serialCode;

        var activityBatch = await DbSet.AsNoTracking().Where(x => x.Batch == activity.Batch).ToArrayAsync();
        if (activityBatch.Length > 0)
        {
            var lastSerial = activityBatch.OrderByDescending(x => x.BatchLine).First();
            serialCode = $"{(lastSerial.BatchLine.ToNumValue()+1).ToString(CultureInfo.InvariantCulture).ToFiveChar()}".ToFiveChar();

            return (activity.Batch, serialCode);
        }

        var serverStatus = await Context.ServerStatusSet.Where(x => x.Region == activity.Region).FirstOrDefaultAsync();
        if (serverStatus == null)
        {
            throw new InvalidEnumArgumentException(activity.Region);
        }

        var serverStatusPersistence = new ServerStatusPersistence(DatabaseFactory);
        serverStatus.Batch = (serverStatus.Batch.ToNumValue() + 1).ToString(CultureInfo.InvariantCulture);
        await serverStatusPersistence.IncrementBatchAsync(serverStatus);

        var batchCode = $"{serverStatus.Region.ToTwoChar()}{(serverStatus.Batch.ToNumValue()).ToString(CultureInfo.InvariantCulture).ToSixChar()}";

        serialCode = "1".ToFiveChar();

        return (batchCode, serialCode);

    }

    public async Task<Activity[]> GetActivitiesAsync(string tenant, string region, string activityType, string branch)
    {
        var branchObject = await Context.BranchSet.FirstOrDefaultAsync(x => x.Code == branch);
        if (branchObject == null)
        {
            throw new ArgumentNullException(nameof(branch));
        }

        var activities = DbSet.Where(x => 
            x.Tenant == tenant && 
            x.Region == region &&
            x.Project == branchObject.Project &&
            x.ActivityType == activityType);

        return await activities.AsNoTracking().ToArrayAsync();
    }

    public async Task<Activity[]> GetActivitiesAsync(string tenant, string region, string activityType,
        DateTime startDate, DateTime endDate)
    {
        return await DbSet.Where(x =>
            x.Tenant == tenant &&
            x.Region == region &&
            x.ActivityType == activityType &&
            x.TransDate.Date >= startDate.Date &&
            x.TransDate.Date <= endDate.Date).AsNoTracking().ToArrayAsync();
    }

    public async Task<Activity[]> GetActivityJournalWithHistoryAsync(string tenant, string region, string project, string activityType,
        DateTime startDate, DateTime endDate)
    {
        var currentActivities = await DbSet.Where(x =>
            x.Tenant == tenant &&
            x.Region == region &&
            x.Project == project &&
            x.ActivityType == activityType &&
            x.TransDate.Date >= startDate.Date &&
            x.TransDate.Date <= endDate.Date).AsNoTracking().ToArrayAsync();

        var activityHistoryPersistence = new ActivityHistoryPersistence(DatabaseFactory);
        var activitiesHistory =
            await activityHistoryPersistence.GetActivityHistoryJournalAsync(tenant, region, project, activityType, startDate,
                endDate);

        return currentActivities.Concat(activitiesHistory).OrderBy(x=>x.Batch).ThenBy(x=>x.BatchLine).ToArray();
    }

    public async Task<Activity[]> GetActivityJournalHistoryAsync(string tenant, string runner, string transactionCode, string activityType, string project)
    {

        var activityHistoryPersistence = new ActivityHistoryPersistence(DatabaseFactory);
        return await activityHistoryPersistence.GetActivityHistoryJournalAsync(tenant, runner,  transactionCode, activityType, project);
    }

    protected override async Task<Activity> ItemToGetAsync(Activity activity) => await GetFirstOrDefaultAsync(x =>
        x.Tenant == activity.Tenant && x.Batch == activity.Batch && x.BatchLine == activity.BatchLine &&
        x.Project == activity.Project);
}