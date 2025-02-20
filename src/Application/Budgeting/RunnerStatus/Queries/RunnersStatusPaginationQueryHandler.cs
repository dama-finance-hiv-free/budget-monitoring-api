using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerStatus.Queries;

public class RunnersStatusPaginationQueryHandler : RequestHandlerBase, IRequestHandler<RunnersStatusPaginationQuery, RunnerStatusVm[]>
{
    private readonly IRunnerStatusService _runnerStatusService;

    public RunnersStatusPaginationQueryHandler(IRunnerStatusService runnerStatusService)
    {
        _runnerStatusService = runnerStatusService;
    }

    public async Task<RunnerStatusVm[]> Handle(RunnersStatusPaginationQuery request, CancellationToken cancellationToken) =>
        await _runnerStatusService.GetAllAsync(true, request.Page, request.Count);
}
