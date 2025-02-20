using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodComponent.Queries;

public class RunnerPeriodComponentQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodComponentQuery, RunnerPeriodComponentVm>
{
    private readonly IRunnerPeriodComponentService _runnerPeriodComponentService;

    public RunnerPeriodComponentQueryHandler(IRunnerPeriodComponentService runnerPeriodComponentService)
    {
        _runnerPeriodComponentService = runnerPeriodComponentService;
    }

    public async Task<RunnerPeriodComponentVm> Handle(RunnerPeriodComponentQuery request, CancellationToken cancellationToken) =>
        await _runnerPeriodComponentService.GetAsync(request.Tenant, request.RunnerPeriod);
}