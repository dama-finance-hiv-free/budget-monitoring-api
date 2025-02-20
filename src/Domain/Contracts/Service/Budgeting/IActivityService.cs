using System;
using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IActivityService : IServiceBase<ActivityVm>
{
    Task<ActivityVm[]> GetActivitiesAsync(string tenant, string region, string activityType, string branch);
    Task<ActivityLookupSet> GetLookupSetsAsync(string tenant);
    Task UpdateCacheAsync(string tenant, string region, string activityType, string branch, string project);
    Task<ActivityVm[]> GetActivitiesAsync(string tenant, string region, string activityType, DateTime startDate,
        DateTime endDate);

    Task<ActivityVm[]> GetActivityHistories(ActivityHistoryOptionsVm options);

    Task<ActivityVm[]> GetActivityJournalWithHistoryAsync(string tenant, string region, string project, string activityType,
        DateTime startDate, DateTime endDate);

    Task<ActivitySummaryVm[]> GetActivityHistorySummaryAsync(string tenant, string runner, string transactionCode, string activityType, string project);

    Task<ActivityVm[]> GetBatchActivitiesAsync(string batchCode);
}
