using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Zone;

public class ZoneService : ServiceBase<Domain.Entity.Budgeting.Zone, ZoneVm>, IZoneService
{
    private readonly IZonePersistence _zonePersistence;
    private readonly IMapper _mapper;

    public ZoneService(IDataPersistence<Domain.Entity.Budgeting.Zone> persistence, IMapper mapper,
        IDistributedCache cache, IZonePersistence zonePersistence) : base(persistence, mapper, cache)
    {
        _zonePersistence = zonePersistence;
        _mapper = mapper;
    }
}