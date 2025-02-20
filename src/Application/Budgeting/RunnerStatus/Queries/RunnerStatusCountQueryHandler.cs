using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerStatus.Queries;

public class RunnerStatusCountQueryHandler : RequestHandlerBase, IRequestHandler<RunnerStatusCountQuery, int>
{
    private readonly IRunnerStatusService _runnerStatusService;

    public RunnerStatusCountQueryHandler(IRunnerStatusService runnerStatusService)
    {
        _runnerStatusService = runnerStatusService;
    }

    public async Task<int> Handle(RunnerStatusCountQuery request, CancellationToken cancellationToken) =>
        await _runnerStatusService.GetCount(true);
}