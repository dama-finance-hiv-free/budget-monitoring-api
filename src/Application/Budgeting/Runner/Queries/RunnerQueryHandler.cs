using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Runner.Queries;

public class RunnerQueryHandler : RequestHandlerBase, IRequestHandler<RunnerQuery, RunnerVm>
{
    private readonly IRunnerService _runnerService;

    public RunnerQueryHandler(IRunnerService runnerService)
    {
        _runnerService = runnerService;
    }

    public async Task<RunnerVm> Handle(RunnerQuery request, CancellationToken cancellationToken) =>
        await _runnerService.GetAsync(request.Tenant, request.Code);
}