using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponentHistory.Queries;

public class RunnerComponentHistoryCountQueryHandler : RequestHandlerBase, IRequestHandler<RunnerComponentHistoryCountQuery, int>
{
    private readonly IRunnerComponentHistoryService _runnerComponentHistoryService;

    public RunnerComponentHistoryCountQueryHandler(IRunnerComponentHistoryService runnerComponentHistoryService)
    {
        _runnerComponentHistoryService = runnerComponentHistoryService;
    }

    public async Task<int> Handle(RunnerComponentHistoryCountQuery request, CancellationToken cancellationToken) =>
        await _runnerComponentHistoryService.GetCount(true);
}