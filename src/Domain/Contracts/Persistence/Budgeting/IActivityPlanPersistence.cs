using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IActivityPlanPersistence : IDataPersistence<ActivityPlan>
{
    Task<ActivityPlan[]> GetActivityPlansAsync(string tenant);
    Task<ActivityPlan[]> GetActivityPlansAsync(string tenant, string copYear, string component, string project);
    Task<ActivityPlan[]> GetSurgeActivityPlansAsync(string tenant, string copYear, string component, string project);
}
