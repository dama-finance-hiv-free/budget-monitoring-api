using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Region;

public class RegionService : ServiceBase<Domain.Entity.Budgeting.Region, RegionVm>, IRegionService
{
    private readonly IRegionPersistence _regionPersistence;

    public RegionService(IDataPersistence<Domain.Entity.Budgeting.Region> persistence, IMapper mapper,
        IDistributedCache cache, IRegionPersistence regionPersistence) : base(persistence, mapper, cache)
    {
        _regionPersistence = regionPersistence;
    }

    public async Task<RegionVm[]> GetRegionsAsync()
        => await GetCachedItemsAsync(() => _regionPersistence.GetAllAsync());
    
    public async Task<string[]> GetRegionCodesAsync()
    {
        var regionCodes = await GetRegionsAsync();
        return regionCodes.Select(x => x.Code).ToArray();
    }
}