using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface ICopYearSiteService : IServiceBase<CopYearSiteVm>
{
    Task<CopYearSiteVm[]> GetCopYearSitesAsync(string tenant);
}