using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Queries;

public class RunnerPeriodQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodQuery, RunnerPeriodVm>
{
    private readonly IRunnerPeriodService _runnerPeriodService;

    public RunnerPeriodQueryHandler(IRunnerPeriodService runnerPeriodService)
    {
        _runnerPeriodService = runnerPeriodService;
    }

    public async Task<RunnerPeriodVm> Handle(RunnerPeriodQuery request, CancellationToken cancellationToken) =>
        await _runnerPeriodService.GetAsync(request.Tenant, request.Code);
}