using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Queries;

public class ActivityPlanQueryHandler : RequestHandlerBase, IRequestHandler<ActivityPlanQuery, ActivityPlanVm>
{
    private readonly IActivityPlanService _activityPlanService;

    public ActivityPlanQueryHandler(IActivityPlanService activityPlanService)
    {
        _activityPlanService = activityPlanService;
    }

    public async Task<ActivityPlanVm> Handle(ActivityPlanQuery request, CancellationToken cancellationToken) =>
        await _activityPlanService.GetAsync(request.Tenant, request.Code);
}