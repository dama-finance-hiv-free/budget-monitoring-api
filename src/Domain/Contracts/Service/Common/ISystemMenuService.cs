using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Contracts.Service.Common;

public interface ISystemMenuService : IServiceBase<SystemMenuVm>
{
    Task<SystemMenuVm[]> GetRoleMenusAsync(string tenant, string role);
}