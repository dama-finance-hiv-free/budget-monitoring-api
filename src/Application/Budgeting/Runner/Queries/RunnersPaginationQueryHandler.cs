using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Runner.Queries;

public class RunnersPaginationQueryHandler : RequestHandlerBase, IRequestHandler<RunnersPaginationQuery, RunnerVm[]>
{
    private readonly IRunnerService _runnerService;

    public RunnersPaginationQueryHandler(IRunnerService runnerService)
    {
        _runnerService = runnerService;
    }

    public async Task<RunnerVm[]> Handle(RunnersPaginationQuery request, CancellationToken cancellationToken) =>
        await _runnerService.GetAllAsync(true, request.Page, request.Count);
}
