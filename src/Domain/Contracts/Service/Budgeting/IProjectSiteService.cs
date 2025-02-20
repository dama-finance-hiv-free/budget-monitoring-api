using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IProjectSiteService : IServiceBase<ProjectSiteVm>
{
    Task<ProjectSiteVm[]> GetProjectSitesAsync(string tenant);

    Task<string[]> GetProjectSiteCodesAsync(string tenant);
}