using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.RegionRunnerPeriod;

public class RegionRunnerPeriodService : ServiceBase<Domain.Entity.Budgeting.RegionRunnerPeriod, RegionRunnerPeriodVm>,
    IRegionRunnerPeriodService
{
    private readonly IRegionRunnerPeriodPersistence _regionRunnerPeriodPersistence;
    private readonly IMapper _mapper;

    public RegionRunnerPeriodService(IDataPersistence<Domain.Entity.Budgeting.RegionRunnerPeriod> persistence,
        IMapper mapper, IDistributedCache cache, IRegionRunnerPeriodPersistence regionRunnerPeriodPersistence) : base(
        persistence, mapper, cache)
    {
        _regionRunnerPeriodPersistence = regionRunnerPeriodPersistence;
        _mapper = mapper;
    }

    public async Task<RegionRunnerPeriodVm[]> GetRegionRunnerPeriodsAsync(string tenant)
    {
        var regionRunnerPeriods = await _regionRunnerPeriodPersistence.GetRegionRunnerPeriodsAsync(tenant);
        return  _mapper.Map<RegionRunnerPeriodVm[]>(regionRunnerPeriods);
    }
}