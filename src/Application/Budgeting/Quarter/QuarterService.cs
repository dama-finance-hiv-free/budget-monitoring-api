using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Quarter;

public class QuarterService : ServiceBase<Domain.Entity.Budgeting.Quarter, QuarterVm>, IQuarterService
{
    private readonly IQuarterPersistence _quarterPersistence;
    private readonly IMapper _mapper;

    public QuarterService(IDataPersistence<Domain.Entity.Budgeting.Quarter> persistence, IMapper mapper,
        IDistributedCache cache, IQuarterPersistence quarterPersistence) : base(persistence, mapper, cache)
    {
        _quarterPersistence = quarterPersistence;
        _mapper = mapper;
    }

    public async Task<QuarterVm[]> GetQuartersAsync(string tenant)
    {
        var quarters = await _quarterPersistence.GetQuartersAsync(tenant);
        return  _mapper.Map<QuarterVm[]>(quarters);
    }
}