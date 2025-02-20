using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodStatus.Queries;

public class RunnerPeriodStatusQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodStatusQuery, RunnerPeriodStatusVm>
{
    private readonly IRunnerPeriodStatusService _runnerPeriodStatusService;

    public RunnerPeriodStatusQueryHandler(IRunnerPeriodStatusService runnerPeriodStatusService)
    {
        _runnerPeriodStatusService = runnerPeriodStatusService;
    }

    public async Task<RunnerPeriodStatusVm> Handle(RunnerPeriodStatusQuery request, CancellationToken cancellationToken) =>
        await _runnerPeriodStatusService.GetAsync(request.Code, request.Code);
}