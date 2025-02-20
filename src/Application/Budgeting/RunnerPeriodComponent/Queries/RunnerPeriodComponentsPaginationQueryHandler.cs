using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodComponent.Queries;

public class RunnerPeriodComponentsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodComponentsPaginationQuery, RunnerPeriodComponentVm[]>
{
    private readonly IRunnerPeriodComponentService _runnerPeriodComponentService;

    public RunnerPeriodComponentsPaginationQueryHandler(IRunnerPeriodComponentService runnerPeriodComponentService)
    {
        _runnerPeriodComponentService = runnerPeriodComponentService;
    }

    public async Task<RunnerPeriodComponentVm[]> Handle(RunnerPeriodComponentsPaginationQuery request, CancellationToken cancellationToken) =>
        await _runnerPeriodComponentService.GetAllAsync(true, request.Page, request.Count);
}
