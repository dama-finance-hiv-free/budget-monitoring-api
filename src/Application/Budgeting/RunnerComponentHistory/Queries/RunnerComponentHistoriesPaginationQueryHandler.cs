using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponentHistory.Queries;

public class RunnerComponentHistoriesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<RunnerComponentHistoriesPaginationQuery, RunnerComponentHistoryVm[]>
{
    private readonly IRunnerComponentHistoryService _runnerComponentHistoryService;

    public RunnerComponentHistoriesPaginationQueryHandler(IRunnerComponentHistoryService runnerComponentHistoryService)
    {
        _runnerComponentHistoryService = runnerComponentHistoryService;
    }

    public async Task<RunnerComponentHistoryVm[]> Handle(RunnerComponentHistoriesPaginationQuery request, CancellationToken cancellationToken) =>
        await _runnerComponentHistoryService.GetAllAsync(true, request.Page, request.Count);
}
