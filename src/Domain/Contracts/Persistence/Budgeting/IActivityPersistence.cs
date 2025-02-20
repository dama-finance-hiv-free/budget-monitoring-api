using System;
using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IActivityPersistence : IDataPersistence<Activity>
{
   Task<Activity[]> GetActivitiesAsync(string tenant, string region, string activityType, string branch);
   Task<Activity[]> GetActivitiesAsync(string tenant, string region, string activityType, DateTime startDate,
      DateTime endDate);

   Task<Activity[]> GetActivityJournalWithHistoryAsync(string tenant, string region, string project, string activityType,
       DateTime startDate, DateTime endDate);

   Task<Activity[]> GetActivityJournalHistoryAsync(string tenant, string runner, string transactionCode, string activityType,string project);
}
