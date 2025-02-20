using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponent.Queries;

public class RunnerComponentsQueryHandler : RequestHandlerBase, IRequestHandler<RunnerComponentsQuery, RunnerComponentVm[]>
{
    private readonly IRunnerComponentService _runnerComponentService;

    public RunnerComponentsQueryHandler(IRunnerComponentService runnerComponentService)
    {
        _runnerComponentService = runnerComponentService;
    }

    public async Task<RunnerComponentVm[]> Handle(RunnerComponentsQuery request, CancellationToken cancellationToken) => 
        await _runnerComponentService.GetAllAsync(true);
}
