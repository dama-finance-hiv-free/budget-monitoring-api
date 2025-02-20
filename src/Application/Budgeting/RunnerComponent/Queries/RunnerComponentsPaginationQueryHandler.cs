using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponent.Queries;

public class RunnerComponentsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<RunnerComponentsPaginationQuery, RunnerComponentVm[]>
{
    private readonly IRunnerComponentService _runnerComponentService;

    public RunnerComponentsPaginationQueryHandler(IRunnerComponentService runnerComponentService)
    {
        _runnerComponentService = runnerComponentService;
    }

    public async Task<RunnerComponentVm[]> Handle(RunnerComponentsPaginationQuery request, CancellationToken cancellationToken) =>
        await _runnerComponentService.GetAllAsync(true, request.Page, request.Count);
}
