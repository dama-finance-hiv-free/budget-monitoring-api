using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Target;

public class TargetService : ServiceBase<Domain.Entity.Budgeting.Target, TargetVm>, ITargetService
{
    private readonly ITargetPersistence _targetPersistence;
    private readonly IMapper _mapper;

    public TargetService(IDataPersistence<Domain.Entity.Budgeting.Target> persistence, IMapper mapper,
        IDistributedCache cache, ITargetPersistence targetPersistence) : base(persistence, mapper, cache)
    {
        _targetPersistence = targetPersistence;
        _mapper = mapper;
    }

    public async Task<TargetVm[]> GetTargetsAsync(string tenant, string region)
    {
        var cacheKey = $"urn:{tenant}:{region}:{typeof(TargetVm)}";
        var targets = await GetCachedItemsAsync(() => _targetPersistence.GetTargetsAsync(tenant, region), cacheKey, 60, 55);
        return  _mapper.Map<TargetVm[]>(targets);
    }
}