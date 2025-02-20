using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IMilestonePersistence : IDataPersistence<Milestone>
{
    Task<Milestone[]> GetMilestonesAsync(string tenant);
    Task<RepositoryActionResult<Milestone>> UpdateProjectionAsync(Milestone milestone);
    Task<RepositoryActionResult<Milestone>> UpdateAchievementAsync(Milestone milestone);
    Task<MilestoneDashboardVm[]> GetMilestoneDashboardBySite(MilestoneDasboardOptions Options);
    Task<ActivityPlan> GetActivityPlanDescription(string code);
    Task<Site> GetSiteDescription(string code);
}
