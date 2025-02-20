using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerHistory.Queries;

public class RunnerHistoriesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<RunnerHistoriesPaginationQuery, RunnerHistoryVm[]>
{
    private readonly IRunnerHistoryService _runnerHistoryService;

    public RunnerHistoriesPaginationQueryHandler(IRunnerHistoryService runnerHistoryService)
    {
        _runnerHistoryService = runnerHistoryService;
    }

    public async Task<RunnerHistoryVm[]> Handle(RunnerHistoriesPaginationQuery request, CancellationToken cancellationToken) =>
        await _runnerHistoryService.GetAllAsync(true, request.Page, request.Count);
}
