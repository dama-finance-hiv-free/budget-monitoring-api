using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodStatus.Queries;

public class RunnerPeriodsStatusQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodsStatusQuery, RunnerPeriodStatusVm[]>
{
    private readonly IRunnerPeriodStatusService _runnerPeriodStatusService;

    public RunnerPeriodsStatusQueryHandler(IRunnerPeriodStatusService runnerPeriodStatusService)
    {
        _runnerPeriodStatusService = runnerPeriodStatusService;
    }

    public async Task<RunnerPeriodStatusVm[]> Handle(RunnerPeriodsStatusQuery request, CancellationToken cancellationToken) => 
        await _runnerPeriodStatusService.GetAllAsync(true);
}
