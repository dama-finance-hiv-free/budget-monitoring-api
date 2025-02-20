using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.RunnerComponent;

public class RunnerComponentService : ServiceBase<Domain.Entity.Budgeting.RunnerComponent, RunnerComponentVm>,
    IRunnerComponentService
{
    private readonly IRunnerComponentPersistence _runnerComponentPersistence;
    private readonly IMapper _mapper;

    public RunnerComponentService(IDataPersistence<Domain.Entity.Budgeting.RunnerComponent> persistence, IMapper mapper,
        IDistributedCache cache, IRunnerComponentPersistence runnerComponentPersistence) : base(persistence, mapper,
        cache)
    {
        _runnerComponentPersistence = runnerComponentPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerComponentVm[]> GetRunnerComponentsAsync(string tenant)
    {
        var runnerComponents = await _runnerComponentPersistence.GetRunnerComponentsAsync(tenant);
        return  _mapper.Map<RunnerComponentVm[]>(runnerComponents);
    }
}