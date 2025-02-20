using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.IncludeRunner;

public class IncludeRunnerService : ServiceBase<Domain.Entity.Budgeting.IncludeRunner, IncludeRunnerVm>, IIncludeRunnerService
{
    private readonly IIncludeRunnerPersistence _includeRunnerPersistence;
    private readonly IMapper _mapper;

    public IncludeRunnerService(IDataPersistence<Domain.Entity.Budgeting.IncludeRunner> persistence, IMapper mapper,
        IDistributedCache cache, IIncludeRunnerPersistence includeRunnerPersistence) : base(persistence, mapper, cache)
    {
        _includeRunnerPersistence = includeRunnerPersistence;
        _mapper = mapper;
    }

    public async Task<IncludeRunnerVm[]> GetIncludeRunnersAsync(string tenant)
    {
        var includeRunners = await _includeRunnerPersistence.GetIncludeRunnersAsync(tenant);
        return  _mapper.Map<IncludeRunnerVm[]>(includeRunners);
    }
}