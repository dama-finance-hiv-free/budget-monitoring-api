using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Core;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class ActivityHistoryPersistence : RepositoryBase<ActivityHistory>, IActivityHistoryPersistence
{
    //private readonly IComponentPersistence _componentPersistence;

    public ActivityHistoryPersistence(IDatabaseFactory databaseFactory /* IComponentPersistence componentPersistence */)
        : base(databaseFactory)
    {
        //_componentPersistence = componentPersistence;
    }

    public override async Task<RepositoryActionResult<ActivityHistory>> AddAsync(ActivityHistory entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastActivityJournalHistory = DbSet.OrderByDescending(x => x.UserCode).ToArray().FirstOrDefault();
            var serial = lastActivityJournalHistory == null
                ? "1".ToTwoChar()
                : (lastActivityJournalHistory.UserCode.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.UserCode = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<ActivityHistory>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<ActivityHistory>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<ActivityHistory>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<ActivityHistory[]> GetActivitiesHistoryAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    public async Task<ActivityHistory[]> GetActivitiesHistoryAsync(string tenant, string region, string activityType,
        string branch, string runner)
    {
        var activities = DbSet.Where(x =>
            x.Tenant == tenant &&
            x.Region == region &&
            x.ActivityType == activityType);

        if (activityType == "01") activities = activities.Where(x => x.Branch == branch);

        return await activities.AsNoTracking().ToArrayAsync();
    }

    public async Task<Activity[]> GetActivityHistoryJournalAsync(string tenant, string region, string project, string activityType,
        DateTime startDate, DateTime endDate)
    {
        var activitiesHistory = await DbSet.Where(x =>
            x.Tenant == tenant &&
            x.Region == region &&
            x.Project == project &&
            x.ActivityType == activityType &&
            x.TransDate.Date >= startDate.Date &&
            x.TransDate.Date <= endDate.Date).AsNoTracking().ToArrayAsync();

        return activitiesHistory.Select(CreateActivity).ToArray();
    }

    public async Task<Activity[]> GetBatchActivitiesAsync(string batchCode)
    {
        var batchActivities = await DbSet.Where(x => x.Batch == batchCode).ToArrayAsync();
        return batchActivities.Select(CreateActivity).ToArray();
    }

    public async Task<Activity[]> GetActivityHistoryJournalAsync(string tenant, string runner, string transactionCode,
        string activityType, string project)
    {
        var activitiesHistory = await DbSet.Where(x =>
            x.Tenant == tenant &&
            x.Runner == runner &&
            x.TranCode == transactionCode &&
            x.ActivityType == activityType &&
            x.Project == project).AsNoTracking().ToArrayAsync();

        return activitiesHistory.Select(CreateActivity).ToArray();
    }

    public async Task<Activity[]> GetActivities(ActivityHistoryOptionsVm options)
    {
        var activityHistories = await DbSet.Where(x =>
                                x.Tenant == options.Tenant &&
                                x.CopYear == options.CopYear &&
                                x.Project == options.Project &&
                                x.Component == options.Component &&
                                x.Runner == options.Runner
                            ).AsNoTracking().ToArrayAsync();

        return activityHistories.Select(CreateActivity).ToArray();
    }

    public async Task<BudgetExecutionVm[]> GetBudgetExecutionsAsync(BudgetAnalysisOptions options)
    {
        var componentPersistence = new ComponentPersistence(DatabaseFactory);
        var selectedComponent = await componentPersistence.GetFirstOrDefaultAsync(x => x.Code == options.Component);

        try
        {
            const string sql = @"select
  p.code,
  p.description,
  @FromDate as FromDate,
  @ToDate as ToDate,
  coalesce(
    (
      select sum(b.amount) from budgeting.budget b
      where b.activity = p.code and b.project = @Project and b.region = @Region and b.component = @Component
    ),
    0
  ) as budgeted,
  coalesce(
    (
      select sum(a.amount)
      from
        (
          select amount, cop_year, project, activity, region, trans_date from budgeting.activity
          union all
          select amount, cop_year, project, activity, region, trans_date from budgeting.activity_history
        ) a
      where
        a.cop_year = @CopYear
        and a.project = @Project
        and a.activity = p.code
        and a.region = @Region
        and a.trans_date >= @FromDate
        and a.trans_date <= @ToDate
    ),
    0
  ) as accumulated,
coalesce(
    (
      select
        sum(a.amount)
      from
        (
          select amount, cop_year, project, activity, region, trans_date from budgeting.activity
          union all
          select amount, cop_year, project, activity, region, trans_date from budgeting.activity_history
        ) a
      where
        a.cop_year = @CopYear
        and a.project = @Project
        and a.activity = p.code
        and a.region = @Region
        and a.trans_date >= @ComponentStartDate
        and a.trans_date <= @CurrentDate
    ),
    0
  ) as actual,
  0 as balance
from budgeting.activity_plan p order by 1";

            var queryParams = new
            {
                options.Region,
                FromDate = options.StartDate,
                ToDate = options.EndDate,
                options.Project,
                options.Component,
                options.CopYear,
                ComponentStartDate = selectedComponent.StartDate.ToUtcDate(),
                CurrentDate = DateTime.UtcNow.ToUtcDate()
            };

            var budgetExecution  = await Db.QueryAsync<BudgetExecutionVm>(sql, queryParams);
            var array = budgetExecution.Where(b => b.Budgeted != 0 || b.Accumulated != 0 || b.Actual != 0 || b.Balance != 0);

            var budgetExecutionVms = array as BudgetExecutionVm[] ?? array.ToArray();
            foreach (var vm in budgetExecutionVms)
            {
                vm.Balance = vm.Budgeted - vm.Accumulated;
            }

            return budgetExecutionVms.ToArray();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    protected override async Task<ActivityHistory> ItemToGetAsync(string tenant, string activityJournalHistory) =>
        await GetFirstOrDefaultAsync(x => x.UserCode == activityJournalHistory);

    protected override async Task<ActivityHistory> ItemToGetAsync(ActivityHistory activityHistory) =>
        await GetFirstOrDefaultAsync(x => x.UserCode == activityHistory.UserCode);

    private static Activity CreateActivity(ActivityHistory activityHistory) =>
        JsonPropertyMapper<ActivityHistory, Activity>.PropertyMap(activityHistory);
}