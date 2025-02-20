using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.RoleMenu;

public class RoleMenuService : ServiceBase<Domain.Entity.Common.RoleMenu, RoleMenuVm>, IRoleMenuService
{
    public RoleMenuService(IDataPersistence<Domain.Entity.Common.RoleMenu> persistence, IMapper mapper,
        IDistributedCache cache) : base(persistence, mapper, cache)
    {
    }
}