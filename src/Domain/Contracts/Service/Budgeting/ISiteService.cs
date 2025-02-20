using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface ISiteService : IServiceBase<SiteVm>
{
    Task<SiteVm[]> GetSitesAsync(string tenant);

    Task<string[]> GetSiteCodesAsync(string tenant);
    Task<SiteVm[]> GetSitesAsync(string tenant, string region);
}