using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponent.Queries;

public class RunnerComponentQueryHandler : RequestHandlerBase, IRequestHandler<RunnerComponentQuery, RunnerComponentVm>
{
    private readonly IRunnerComponentService _runnerComponentService;

    public RunnerComponentQueryHandler(IRunnerComponentService runnerComponentService)
    {
        _runnerComponentService = runnerComponentService;
    }

    public async Task<RunnerComponentVm> Handle(RunnerComponentQuery request, CancellationToken cancellationToken) =>
        await _runnerComponentService.GetAsync(request.Tenant, request.Runner);
}