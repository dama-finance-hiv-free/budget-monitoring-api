using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.Town;

public class TownService : ServiceBase<Domain.Entity.Common.Town, TownVm>, ITownService
{
    public TownService(IDataPersistence<Domain.Entity.Common.Town> persistence, IMapper mapper, IDistributedCache cache)
        : base(persistence, mapper, cache)
    {
    }
}