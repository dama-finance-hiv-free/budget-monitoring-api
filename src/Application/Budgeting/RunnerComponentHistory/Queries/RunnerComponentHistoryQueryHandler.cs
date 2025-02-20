using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponentHistory.Queries;

public class RunnerComponentHistoryQueryHandler : RequestHandlerBase, IRequestHandler<RunnerComponentHistoryQuery, RunnerComponentHistoryVm>
{
    private readonly IRunnerComponentHistoryService _runnerComponentHistoryService;

    public RunnerComponentHistoryQueryHandler(IRunnerComponentHistoryService runnerComponentHistoryService)
    {
        _runnerComponentHistoryService = runnerComponentHistoryService;
    }

    public async Task<RunnerComponentHistoryVm> Handle(RunnerComponentHistoryQuery request, CancellationToken cancellationToken) =>
        await _runnerComponentHistoryService.GetAsync(request.Tenant, request.Runner);

}