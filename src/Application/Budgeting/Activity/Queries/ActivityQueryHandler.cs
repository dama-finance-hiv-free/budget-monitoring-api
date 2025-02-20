using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivityQueryHandler : RequestHandlerBase, IRequestHandler<ActivityQuery, ActivityVm>
{
    private readonly IActivityService _activityService;

    public ActivityQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<ActivityVm> Handle(ActivityQuery request, CancellationToken cancellationToken) =>
        await _activityService.GetAsync(request.Tenant, request.Batch);
}