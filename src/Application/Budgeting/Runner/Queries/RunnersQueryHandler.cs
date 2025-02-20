using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Runner.Queries;

public class RunnersQueryHandler : RequestHandlerBase, IRequestHandler<RunnersQuery, RunnerVm[]>
{
    private readonly IRunnerService _runnerService;

    public RunnersQueryHandler(IRunnerService runnerService)
    {
        _runnerService = runnerService;
    }

    public async Task<RunnerVm[]> Handle(RunnersQuery request, CancellationToken cancellationToken) =>
        await _runnerService.GetRunnersAsync(request.Tenant);
}
