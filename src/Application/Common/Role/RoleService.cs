using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.Role;

public class RoleService : ServiceBase<Domain.Entity.Common.Role, RoleVm>, IRoleService
{
    public RoleService(IDataPersistence<Domain.Entity.Common.Role> persistence, IMapper mapper, IDistributedCache cache)
        : base(persistence, mapper, cache)
    {
    }
}