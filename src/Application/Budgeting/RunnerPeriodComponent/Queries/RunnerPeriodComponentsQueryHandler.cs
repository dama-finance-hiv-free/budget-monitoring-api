using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodComponent.Queries;

public class RunnerPeriodComponentsQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodComponentsQuery, RunnerPeriodComponentVm[]>
{
    private readonly IRunnerPeriodComponentService _runnerPeriodComponentService;

    public RunnerPeriodComponentsQueryHandler(IRunnerPeriodComponentService runnerPeriodComponentService)
    {
        _runnerPeriodComponentService = runnerPeriodComponentService;
    }

    public async Task<RunnerPeriodComponentVm[]> Handle(RunnerPeriodComponentsQuery request, CancellationToken cancellationToken) => 
        await _runnerPeriodComponentService.GetAllAsync(true);
}
