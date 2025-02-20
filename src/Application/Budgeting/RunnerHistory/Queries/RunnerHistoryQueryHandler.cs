using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerHistory.Queries;

public class RunnerHistoryQueryHandler : RequestHandlerBase, IRequestHandler<RunnerHistoryQuery, RunnerHistoryVm>
{
    private readonly IRunnerHistoryService _runnerHistoryService;

    public RunnerHistoryQueryHandler(IRunnerHistoryService runnerHistoryService)
    {
        _runnerHistoryService = runnerHistoryService;
    }

    public async Task<RunnerHistoryVm> Handle(RunnerHistoryQuery request, CancellationToken cancellationToken) =>
        await _runnerHistoryService.GetAsync(request.Tenant, request.Code);
}