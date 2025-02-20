using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.SiteType;

public class SiteTypeService : ServiceBase<Domain.Entity.Budgeting.SiteType, SiteTypeVm>, ISiteTypeService
{
    private readonly ISiteTypePersistence _siteTypePersistence;
    private readonly IMapper _mapper;

    public SiteTypeService(IDataPersistence<Domain.Entity.Budgeting.SiteType> persistence, IMapper mapper,
        IDistributedCache cache, ISiteTypePersistence siteTypePersistence) : base(persistence, mapper, cache)
    {
        _siteTypePersistence = siteTypePersistence;
        _mapper = mapper;
    }

    public async Task<SiteTypeVm[]> GetUserSiteTypesAsync(string tenant)
    {
        var siteTypes = await _siteTypePersistence.GetSiteTypesAsync(tenant);
        return  _mapper.Map<SiteTypeVm[]>(siteTypes);
    }
}