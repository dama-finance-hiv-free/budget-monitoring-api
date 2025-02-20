using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.RunnerStatus;

public class RunnerStatusService : ServiceBase<Domain.Entity.Budgeting.RunnerStatus, RunnerStatusVm>,
    IRunnerStatusService
{
    private readonly IRunnerStatusPersistence _runnerStatusPersistence;
    private readonly IMapper _mapper;

    public RunnerStatusService(IDataPersistence<Domain.Entity.Budgeting.RunnerStatus> persistence, IMapper mapper,
        IDistributedCache cache, IRunnerStatusPersistence runnerStatusPersistence) : base(persistence, mapper, cache)
    {
        _runnerStatusPersistence = runnerStatusPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerStatusVm[]> GetRunnersStatusAsync(string tenant)
    {
        var runnersStatus = await _runnerStatusPersistence.GetRunnersStatusAsync(tenant);
        return  _mapper.Map<RunnerStatusVm[]>(runnersStatus);
    }
}