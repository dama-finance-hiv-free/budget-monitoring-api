using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodStatus.Queries;

public class RunnerPeriodStatusCountQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodStatusCountQuery, int>
{
    private readonly IRunnerPeriodStatusService _runnerPeriodStatusService;

    public RunnerPeriodStatusCountQueryHandler(IRunnerPeriodStatusService runnerPeriodStatusService)
    {
        _runnerPeriodStatusService = runnerPeriodStatusService;
    }

    public async Task<int> Handle(RunnerPeriodStatusCountQuery request, CancellationToken cancellationToken) =>
        await _runnerPeriodStatusService.GetCount(true);
}