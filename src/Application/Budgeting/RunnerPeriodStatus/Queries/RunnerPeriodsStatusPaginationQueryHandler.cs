using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodStatus.Queries;

public class RunnerPeriodsStatusPaginationQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodsStatusPaginationQuery, RunnerPeriodStatusVm[]>
{
    private readonly IRunnerPeriodStatusService _runnerPeriodStatusService;

    public RunnerPeriodsStatusPaginationQueryHandler(IRunnerPeriodStatusService runnerPeriodStatusService)
    {
        _runnerPeriodStatusService = runnerPeriodStatusService;
    }

    public async Task<RunnerPeriodStatusVm[]> Handle(RunnerPeriodsStatusPaginationQuery request, CancellationToken cancellationToken) =>
        await _runnerPeriodStatusService.GetAllAsync(true, request.Page, request.Count);
}
