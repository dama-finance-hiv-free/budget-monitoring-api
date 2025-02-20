using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodComponent.Queries;

public class RunnerPeriodComponentCountQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodComponentCountQuery, int>
{
    private readonly IRunnerPeriodComponentService _runnerPeriodComponentService;

    public RunnerPeriodComponentCountQueryHandler(IRunnerPeriodComponentService runnerPeriodComponentService)
    {
        _runnerPeriodComponentService = runnerPeriodComponentService;
    }

    public async Task<int> Handle(RunnerPeriodComponentCountQuery request, CancellationToken cancellationToken) =>
        await _runnerPeriodComponentService.GetCount(true);
}