using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Queries;

public class RunnerPeriodCountQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodCountQuery, int>
{
    private readonly IRunnerPeriodService _runnerPeriodService;

    public RunnerPeriodCountQueryHandler(IRunnerPeriodService runnerPeriodService)
    {
        _runnerPeriodService = runnerPeriodService;
    }

    public async Task<int> Handle(RunnerPeriodCountQuery request, CancellationToken cancellationToken) =>
        await _runnerPeriodService.GetCount(true);
}