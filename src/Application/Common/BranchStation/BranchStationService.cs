using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.BranchStation;

public class BranchStationService : ServiceBase<Domain.Entity.Common.BranchStation, BranchStationVm>, IBranchStationService
{
    private readonly IBranchStationPersistence _branchStationPersistence;

    public BranchStationService(IDataPersistence<Domain.Entity.Common.BranchStation> persistence, IMapper mapper,
        IDistributedCache cache, IBranchStationPersistence branchStationPersistence) : base(persistence, mapper, cache)
    {
        _branchStationPersistence = branchStationPersistence;
    }
}