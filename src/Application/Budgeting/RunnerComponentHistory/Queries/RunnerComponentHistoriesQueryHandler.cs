using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponentHistory.Queries;

public class RunnerComponentHistoriesQueryHandler : RequestHandlerBase, IRequestHandler<RunnerComponentHistoriesQuery, RunnerComponentHistoryVm[]>
{
    private readonly IRunnerComponentHistoryService _runnerComponentHistoryService;

    public RunnerComponentHistoriesQueryHandler(IRunnerComponentHistoryService runnerComponentHistoryService)
    {
        _runnerComponentHistoryService = runnerComponentHistoryService;
    }

    public async Task<RunnerComponentHistoryVm[]> Handle(RunnerComponentHistoriesQuery request, CancellationToken cancellationToken) => 
        await _runnerComponentHistoryService.GetAllAsync(true);
}
