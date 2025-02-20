using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IActivityPlanService : IServiceBase<ActivityPlanVm>
{
    Task<ActivityPlanVm[]> GetActivityPlansAsync(string tenant);
    Task<string[]> GetActivityPlanCodesAsync(string tenant);
    Task<ActivityPlanVm> GetActivityPlanAsync(string tenant, string code);
    Task<ActivityPlanVm[]> GetActivityPlansAsync(string tenant, string copYear, string component, string project);
    Task<ActivityPlanVm[]> GetSurgeActivityPlansAsync(string tenant, string copYear, string component, string project);
}