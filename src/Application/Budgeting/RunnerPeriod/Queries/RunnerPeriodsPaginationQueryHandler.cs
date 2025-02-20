using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Queries;

public class RunnerPeriodsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodsPaginationQuery, RunnerPeriodVm[]>
{
    private readonly IRunnerPeriodService _runnerPeriodService;

    public RunnerPeriodsPaginationQueryHandler(IRunnerPeriodService runnerPeriodService)
    {
        _runnerPeriodService = runnerPeriodService;
    }

    public async Task<RunnerPeriodVm[]> Handle(RunnerPeriodsPaginationQuery request, CancellationToken cancellationToken) =>
        await _runnerPeriodService.GetAllAsync(true, request.Page, request.Count);
}
