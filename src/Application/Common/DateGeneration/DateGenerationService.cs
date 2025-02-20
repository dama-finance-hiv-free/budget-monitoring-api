using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.DateGeneration;

public class DateGenerationService : ServiceBase<Domain.Entity.Common.DateGeneration, DateGenerationVm>,
    IDateGenerationService
{
    private readonly IDateGenerationPersistence _dateGenerationPersistence;
    private readonly IMapper _mapper;

    public DateGenerationService(IDateGenerationPersistence dateGenerationPersistence,
        IDataPersistence<Domain.Entity.Common.DateGeneration> persistence, IMapper mapper,
        IDistributedCache cache = null) : base(persistence, mapper, cache)
    {
        _dateGenerationPersistence = dateGenerationPersistence;
        _mapper = mapper;
    }

    public async Task<DateGenerationVm[]> GetDateGenerationsAsync(string tenant)
    {
        var dateGenerations = await _dateGenerationPersistence.GetDateGenerationsAsync(tenant);
        return  _mapper.Map<DateGenerationVm[]>(dateGenerations);
    }
}