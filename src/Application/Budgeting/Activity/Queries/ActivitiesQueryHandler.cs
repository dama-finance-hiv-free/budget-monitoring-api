using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivitiesQueryHandler : RequestHandlerBase, IRequestHandler<ActivitiesQuery, ActivityVm[]>
{
    private readonly IActivityService _activityService;

    public ActivitiesQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<ActivityVm[]> Handle(ActivitiesQuery request, CancellationToken cancellationToken) =>
        await _activityService.GetActivitiesAsync(request.Tenant, request.Region, request.ActivityType, request.Branch);
}
