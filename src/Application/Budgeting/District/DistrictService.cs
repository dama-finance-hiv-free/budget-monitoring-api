using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.District;

public class DistrictService : ServiceBase<Domain.Entity.Budgeting.District, DistrictVm>, IDistrictService
{
    private readonly IDistrictPersistence _districtPersistence;
    private readonly IMapper _mapper;

    public DistrictService(IDataPersistence<Domain.Entity.Budgeting.District> persistence, IMapper mapper,
        IDistributedCache cache, IDistrictPersistence districtPersistence) : base(persistence, mapper, cache)
    {
        _districtPersistence = districtPersistence;
        _mapper = mapper;
    }

    public async Task<DistrictVm[]> GetDistrictsAsync(string tenant)
    {
        var districts = await _districtPersistence.GetDistrictsAsync(tenant);
        return  _mapper.Map<DistrictVm[]>(districts);
    }
}