using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Queries;

public class ActivityPlanCountQueryHandler : RequestHandlerBase, IRequestHandler<ActivityPlanCountQuery, int>
{
    private readonly IActivityPlanService _activityPlanService;

    public ActivityPlanCountQueryHandler(IActivityPlanService activityPlanService)
    {
        _activityPlanService = activityPlanService;
    }
    public async Task<int> Handle(ActivityPlanCountQuery request, CancellationToken cancellationToken) =>
        await _activityPlanService.GetCount(true);
}