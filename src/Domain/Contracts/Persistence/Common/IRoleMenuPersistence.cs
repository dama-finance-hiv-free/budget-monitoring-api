using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Entity.Common;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Domain.Contracts.Persistence.Common;

public interface IRoleMenuPersistence : IDataPersistence<RoleMenu>
{
    Task<string[]> GetUserMenusCodesAsync(string tenant, string userCode);
    Task<RepositoryActionResult<RoleMenuDto>> UpdateRoleMenusAsync(RoleMenuDto dto);
    Task<string[]> GetRoleMenuCodesAsync(string tenant, string role);
}