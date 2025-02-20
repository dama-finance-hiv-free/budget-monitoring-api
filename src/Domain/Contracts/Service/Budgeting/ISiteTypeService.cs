using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface ISiteTypeService : IServiceBase<SiteTypeVm>
{
    Task<SiteTypeVm[]> GetUserSiteTypesAsync(string tenant);
}