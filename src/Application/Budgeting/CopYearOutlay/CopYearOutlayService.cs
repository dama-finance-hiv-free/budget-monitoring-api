using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.CopYearOutlay;

public class CopYearOutlayService : ServiceBase<Domain.Entity.Budgeting.CopYearOutlay, CopYearOutlayVm>, ICopYearOutlayService
{
    private readonly ICopYearOutlayPersistence _copYearOutlayPersistence;
    private readonly IMapper _mapper;

    public CopYearOutlayService(IDataPersistence<Domain.Entity.Budgeting.CopYearOutlay> persistence, IMapper mapper,
        IDistributedCache cache, ICopYearOutlayPersistence copYearOutlayPersistence) : base(persistence, mapper, cache)
    {
        _copYearOutlayPersistence = copYearOutlayPersistence;
        _mapper = mapper;
    }

    public async Task<CopYearOutlayVm[]> GetCopYearOutlaysAsync(string tenant)
    {
        var copYearOutlays = await _copYearOutlayPersistence.GetCopYearOutlaysAsync(tenant);
        return  _mapper.Map<CopYearOutlayVm[]>(copYearOutlays);
    }
}