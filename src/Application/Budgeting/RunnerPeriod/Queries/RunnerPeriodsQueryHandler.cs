using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Queries;

public class RunnerPeriodsQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodsQuery, RunnerPeriodVm[]>
{
    private readonly IRunnerPeriodService _runnerPeriodService;

    public RunnerPeriodsQueryHandler(IRunnerPeriodService runnerPeriodService)
    {
        _runnerPeriodService = runnerPeriodService;
    }

    public async Task<RunnerPeriodVm[]> Handle(RunnerPeriodsQuery request, CancellationToken cancellationToken) => 
        await _runnerPeriodService.GetRunnerPeriodsAsync(request.Tenant);
}