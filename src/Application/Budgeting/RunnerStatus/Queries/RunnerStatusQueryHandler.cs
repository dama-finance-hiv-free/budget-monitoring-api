using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerStatus.Queries;

public class RunnerStatusQueryHandler : RequestHandlerBase, IRequestHandler<RunnerStatusQuery, RunnerStatusVm>
{
    private readonly IRunnerStatusService _runnerStatusService;

    public RunnerStatusQueryHandler(IRunnerStatusService runnerStatusService)
    {
        _runnerStatusService = runnerStatusService;
    }

    public async Task<RunnerStatusVm> Handle(RunnerStatusQuery request, CancellationToken cancellationToken) =>
        await _runnerStatusService.GetAsync(request.Code, request.Code);
}