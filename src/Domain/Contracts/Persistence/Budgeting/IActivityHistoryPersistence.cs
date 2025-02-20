using System;
using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IActivityHistoryPersistence : IDataPersistence<ActivityHistory>
{
   Task<ActivityHistory[]> GetActivitiesHistoryAsync(string tenant);
   Task<ActivityHistory[]> GetActivitiesHistoryAsync(string tenant, string region, string activityType, string branch, string runner);

   Task<Activity[]> GetActivityHistoryJournalAsync(string tenant, string region, string project, string activityType,
       DateTime startDate, DateTime endDate);

   Task<Activity[]> GetActivities(ActivityHistoryOptionsVm options);
   Task<Activity[]> GetActivityHistoryJournalAsync(string tenant, string runner, string transactionCode, string activityType, string project);

   Task<Activity[]> GetBatchActivitiesAsync(string batchCode);
    Task<BudgetExecutionVm[]> GetBudgetExecutionsAsync(BudgetAnalysisOptions options);
}
