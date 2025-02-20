using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodComponent;

public class RunnerPeriodComponentService : ServiceBase<Domain.Entity.Budgeting.RunnerPeriodComponent, RunnerPeriodComponentVm>, IRunnerPeriodComponentService
{
    private readonly IRunnerPeriodComponentPersistence _runnerPeriodComponentPersistence;
    private readonly IMapper _mapper;

    public RunnerPeriodComponentService(IDataPersistence<Domain.Entity.Budgeting.RunnerPeriodComponent> persistence,
        IMapper mapper, IDistributedCache cache, IRunnerPeriodComponentPersistence runnerPeriodComponentPersistence) :
        base(persistence, mapper, cache)
    {
        _runnerPeriodComponentPersistence = runnerPeriodComponentPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerPeriodComponentVm[]> GetRunnerPeriodComponentsAsync(string tenant)
    {
        var runnerPeriodComponents = await _runnerPeriodComponentPersistence.GetRunnerPeriodComponentsAsync(tenant);
        return  _mapper.Map<RunnerPeriodComponentVm[]>(runnerPeriodComponents);
    }
}