using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Contracts.Service.Common;

public interface IUserMenuService : IServiceBase<UserRoleVm>
{
    Task<UserMenuVm[]> GetUserMenuCodesAsync(string tenant, string code, string lid);
}