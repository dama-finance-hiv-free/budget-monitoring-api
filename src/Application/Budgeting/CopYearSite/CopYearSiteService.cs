using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.CopYearSite;

public class CopYearSiteService : ServiceBase<Domain.Entity.Budgeting.CopYearSite, CopYearSiteVm>, ICopYearSiteService
{
    private readonly ICopYearSitePersistence _copYearSitePersistence;
    private readonly IMapper _mapper;

    public CopYearSiteService(IDataPersistence<Domain.Entity.Budgeting.CopYearSite> persistence, IMapper mapper,
        IDistributedCache cache, ICopYearSitePersistence copYearSitePersistence) : base(persistence, mapper, cache)
    {
        _copYearSitePersistence = copYearSitePersistence;
        _mapper = mapper;
    }

    public async Task<CopYearSiteVm[]> GetCopYearSitesAsync(string tenant)
    {
        var copYearSites = await _copYearSitePersistence.GetCopYearSitesAsync(tenant);
        return  _mapper.Map<CopYearSiteVm[]>(copYearSites);
    }
}