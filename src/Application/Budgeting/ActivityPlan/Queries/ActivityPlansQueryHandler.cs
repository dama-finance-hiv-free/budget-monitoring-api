using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Queries;

public class ActivityPlansQueryHandler : RequestHandlerBase, IRequestHandler<ActivityPlansQuery, ActivityPlanVm[]>
{
    private readonly IActivityPlanService _activityPlanService;

    public ActivityPlansQueryHandler(IActivityPlanService activityPlanService)
    {
        _activityPlanService = activityPlanService;
    }

    public async Task<ActivityPlanVm[]> Handle(ActivityPlansQuery request, CancellationToken cancellationToken) =>
        await _activityPlanService.GetActivityPlansAsync(request.Tenant, request.CopYear, request.Component,
            request.Project);

}