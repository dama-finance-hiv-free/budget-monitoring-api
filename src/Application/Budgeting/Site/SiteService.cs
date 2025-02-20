using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Site;

public class SiteService : ServiceBase<Domain.Entity.Budgeting.Site, SiteVm>, ISiteService
{
    private readonly ISitePersistence _sitePersistence;

    public SiteService(IDataPersistence<Domain.Entity.Budgeting.Site> persistence, IMapper mapper,
        IDistributedCache cache, ISitePersistence sitePersistence) : base(persistence, mapper, cache)
    {
        _sitePersistence = sitePersistence;
    }

    public async Task<SiteVm[]> GetSitesAsync(string tenant)
        => await GetCachedItemsAsync(() => _sitePersistence.GetSitesAsync(tenant));

    public async Task<SiteVm[]> GetSitesAsync(string tenant, string region)
    {
        var cacheKey = $"urn:{tenant}:{region}:{typeof(SiteVm[])}";
        return await GetCachedItemsAsync(() => _sitePersistence.GetSitesAsync(tenant, region), cacheKey);
    }

    public async Task<string[]> GetSiteCodesAsync(string tenant)
    {
        var siteCodes = await GetSitesAsync(tenant);
        return siteCodes.Select(x => x.Code).ToArray();
    }
}