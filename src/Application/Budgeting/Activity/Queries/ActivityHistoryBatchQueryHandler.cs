using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivityHistoryBatchQueryHandler : RequestHandlerBase, IRequestHandler<ActivityHistoryBatchQuery, ActivityVm[]>
{
    private readonly IActivityService _activityService;

    public ActivityHistoryBatchQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<ActivityVm[]> Handle(ActivityHistoryBatchQuery request, CancellationToken cancellationToken) =>
        await _activityService.GetBatchActivitiesAsync(request.BatchCode);
}