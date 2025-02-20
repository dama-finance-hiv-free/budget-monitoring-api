using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Queries;

public class SurgeActivityPlansQueryHandler : RequestHandlerBase, IRequestHandler<SurgeActivityPlansQuery, ActivityPlanVm[]>
{
    private readonly IActivityPlanService _activityPlanService;

    public SurgeActivityPlansQueryHandler(IActivityPlanService activityPlanService)
    {
        _activityPlanService = activityPlanService;
    }

    public async Task<ActivityPlanVm[]> Handle(SurgeActivityPlansQuery request, CancellationToken cancellationToken) =>
        await _activityPlanService.GetSurgeActivityPlansAsync(request.Tenant, request.CopYear, request.Component,
            request.Project);

}