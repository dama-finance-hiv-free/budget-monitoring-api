using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Queries;

public class RunnerPeriodHistoryCodesQueryHandler : RequestHandlerBase, IRequestHandler<RunnerPeriodHistoryCodesQuery, string[]>
{
    private readonly IRunnerPeriodService _runnerPeriodService;

    public RunnerPeriodHistoryCodesQueryHandler(IRunnerPeriodService runnerPeriodService)
    {
        _runnerPeriodService = runnerPeriodService;
    }

    public async Task<string[]> Handle(RunnerPeriodHistoryCodesQuery request, CancellationToken cancellationToken) =>
        await _runnerPeriodService.GetRunnerPeriodHistoryCodesAsync(request.Tenant, request.Region, request.CopYear,
            request.Project);
}