using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.SystemMenu;

public class SystemMenuService : ServiceBase<Domain.Entity.Common.SystemMenu, SystemMenuVm>, ISystemMenuService
{
    private readonly IRoleMenuPersistence _roleMenuPersistence;
    private readonly ISystemMenuPersistence _systemMenuPersistence;
    private readonly IMapper _mapper;

    public SystemMenuService(IDataPersistence<Domain.Entity.Common.SystemMenu> persistence, IMapper mapper,
        IDistributedCache cache, IRoleMenuPersistence roleMenuPersistence, ISystemMenuPersistence systemMenuPersistence)
        : base(persistence, mapper, cache)
    {
        _roleMenuPersistence = roleMenuPersistence;
        _systemMenuPersistence = systemMenuPersistence;
        _mapper = mapper;
    }

    public async Task<SystemMenuVm[]> GetRoleMenusAsync(string tenant, string role)
    {
        var systemMenus = await _systemMenuPersistence.GetSystemMenusAsync("01");
        var roleMenuCodes = await _roleMenuPersistence.GetRoleMenuCodesAsync(tenant, role);
        var roleMenus = systemMenus.Where(x => roleMenuCodes.Contains(x.Code));

        return _mapper.Map<SystemMenuVm[]>(roleMenus);
    }
}