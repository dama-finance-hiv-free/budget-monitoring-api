using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerHistory.Queries;

public class RunnerHistoryCountQueryHandler : RequestHandlerBase, IRequestHandler<RunnerHistoryCountQuery, int>
{
    private readonly IRunnerHistoryService _runnerHistoryService;

    public RunnerHistoryCountQueryHandler(IRunnerHistoryService runnerHistoryService)
    {
        _runnerHistoryService = runnerHistoryService;
    }

    public async Task<int> Handle(RunnerHistoryCountQuery request, CancellationToken cancellationToken) =>
        await _runnerHistoryService.GetCount(true);
}