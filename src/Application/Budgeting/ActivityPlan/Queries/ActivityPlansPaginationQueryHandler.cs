using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Queries;

public class ActivityPlansPaginationQueryHandler : RequestHandlerBase, IRequestHandler<ActivityPlansPaginationQuery, ActivityPlanVm[]>
{
    private readonly IActivityPlanService _activityPlanService;

    public ActivityPlansPaginationQueryHandler(IActivityPlanService activityPlanService)
    {
        _activityPlanService = activityPlanService;
    }

    public async Task<ActivityPlanVm[]> Handle(ActivityPlansPaginationQuery request, CancellationToken cancellationToken) =>
        await _activityPlanService.GetAllAsync(true, request.Page, request.Count);
}
