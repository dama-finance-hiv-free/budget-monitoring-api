using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.Privilege;

public class PrivilegeService : ServiceBase<Domain.Entity.Common.Privilege, PrivilegeVm>, IPrivilegeService
{
    public PrivilegeService(IDataPersistence<Domain.Entity.Common.Privilege> persistence, IMapper mapper,
        IDistributedCache cache) : base(persistence, mapper, cache)
    {
    }
}