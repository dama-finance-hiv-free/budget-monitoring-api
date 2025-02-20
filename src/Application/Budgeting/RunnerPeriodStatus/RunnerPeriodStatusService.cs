using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodStatus;

public class RunnerPeriodStatusService : ServiceBase<Domain.Entity.Budgeting.RunnerPeriodStatus, RunnerPeriodStatusVm>,
    IRunnerPeriodStatusService
{
    private readonly IRunnerPeriodStatusPersistence _runnerPeriodStatusPersistence;
    private readonly IMapper _mapper;

    public RunnerPeriodStatusService(IDataPersistence<Domain.Entity.Budgeting.RunnerPeriodStatus> persistence,
        IMapper mapper, IDistributedCache cache, IRunnerPeriodStatusPersistence runnerPeriodStatusPersistence) : base(
        persistence, mapper, cache)
    {
        _runnerPeriodStatusPersistence = runnerPeriodStatusPersistence;
        _mapper = mapper;
    }

    public async Task<RunnerPeriodStatusVm[]> GetRunnerPeriodsStatusAsync(string tenant)
    {
        var runnerPeriodsStatus = await _runnerPeriodStatusPersistence.GetRunnerPeriodsStatusAsync(tenant);
        return  _mapper.Map<RunnerPeriodStatusVm[]>(runnerPeriodsStatus);
    }
}