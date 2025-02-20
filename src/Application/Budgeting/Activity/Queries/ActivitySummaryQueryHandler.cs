using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivitySummaryQueryHandler : RequestHandlerBase, IRequestHandler<ActivitySummaryQuery, ActivitySummaryVm[]>
{
    private readonly IActivityService _activityService;

    public ActivitySummaryQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<ActivitySummaryVm[]> Handle(ActivitySummaryQuery request, CancellationToken cancellationToken) =>
        await _activityService.GetActivityHistorySummaryAsync(request.Options.Tenant, request.Options.Runner, request.Options.TransactionCode,
            request.Options.ActivityType, request.Options.Project);
}
