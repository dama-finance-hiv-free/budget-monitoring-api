using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerHistory.Queries;

public class RunnerHistoriesQueryHandler : RequestHandlerBase, IRequestHandler<RunnerHistoriesQuery, RunnerHistoryVm[]>
{
    private readonly IRunnerHistoryService _runnerHistoryService;

    public RunnerHistoriesQueryHandler(IRunnerHistoryService runnerHistoryService)
    {
        _runnerHistoryService = runnerHistoryService;
    }

    public async Task<RunnerHistoryVm[]> Handle(RunnerHistoriesQuery request, CancellationToken cancellationToken) => 
        await _runnerHistoryService.GetAllAsync(true);
}
