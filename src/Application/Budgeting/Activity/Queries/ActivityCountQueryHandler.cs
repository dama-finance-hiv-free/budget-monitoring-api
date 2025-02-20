using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivityCountQueryHandler : RequestHandlerBase, IRequestHandler<ActivityCountQuery, int>
{
    private readonly IActivityService _activityService;

    public ActivityCountQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<int> Handle(ActivityCountQuery request, CancellationToken cancellationToken) =>
        await _activityService.GetCount(true);
}