using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.UserMenu;

public class UserMenuService : ServiceBase<Domain.Entity.Common.UserRole, UserRoleVm>, IUserMenuService
{
    private readonly IRoleMenuPersistence _roleMenuPersistence;
    private readonly ISystemMenuPersistence _systemMenuPersistence;

    public UserMenuService(IDataPersistence<Domain.Entity.Common.UserRole> persistence, IMapper mapper,
        IDistributedCache cache, IRoleMenuPersistence roleMenuPersistence, ISystemMenuPersistence systemMenuPersistence)
        : base(persistence, mapper, cache)
    {
        _roleMenuPersistence = roleMenuPersistence;
        _systemMenuPersistence = systemMenuPersistence;
    }

    public async Task<UserMenuVm[]> GetUserMenuCodesAsync(string tenant, string code, string lid)
    {
        var userMenusCodes = await _roleMenuPersistence.GetUserMenusCodesAsync(tenant, code);
        var systemMenus = await _systemMenuPersistence.GetSystemMenusAsync(lid);

        var userMenus = new UserMenuVm[userMenusCodes.Length];
        var i = 0;
        foreach (var userMenusCode in userMenusCodes)
        {
            var userMenu = new UserMenuVm
            {
                App = systemMenus.FirstOrDefault(s => s.Code == userMenusCode)?.App,
                UsrCode = code,
                Language = systemMenus.FirstOrDefault(s => s.Code == userMenusCode)?.Lid,
                MenCode = userMenusCode,
                MenDescription = systemMenus.FirstOrDefault(s => s.Code == userMenusCode)?.Description,
                Status = systemMenus.FirstOrDefault(s => s.Code == userMenusCode)?.Status
            };
            userMenus[i] = userMenu;
            i++;
        }
        return userMenus;
    }
}