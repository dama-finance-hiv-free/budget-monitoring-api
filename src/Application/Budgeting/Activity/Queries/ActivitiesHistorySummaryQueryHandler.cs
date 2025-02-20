using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivitiesHistorySummaryQueryHandler : RequestHandlerBase, IRequestHandler<ActivitiesHistorySummaryQuery, ActivityVm[]>
{
    private readonly IActivityService _activityService;

    public ActivitiesHistorySummaryQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<ActivityVm[]> Handle(ActivitiesHistorySummaryQuery request, CancellationToken cancellationToken) => 
        await _activityService.GetActivityHistories(request.Options);
}
