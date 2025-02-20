using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerStatus.Queries;

public class RunnersStatusQueryHandler : RequestHandlerBase, IRequestHandler<RunnersStatusQuery, RunnerStatusVm[]>
{
    private readonly IRunnerStatusService _runnerStatusService;

    public RunnersStatusQueryHandler(IRunnerStatusService runnerStatusService)
    {
        _runnerStatusService = runnerStatusService;
    }

    public async Task<RunnerStatusVm[]> Handle(RunnersStatusQuery request, CancellationToken cancellationToken) => 
        await _runnerStatusService.GetAllAsync(true);
}
