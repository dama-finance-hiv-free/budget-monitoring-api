using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivitiesHistoryPaginationQueryHandler : RequestHandlerBase, IRequestHandler<ActivitiesHistoryPaginationQuery, ActivityVm[]>
{
    private readonly IActivityService _activityService;

    public ActivitiesHistoryPaginationQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<ActivityVm[]> Handle(ActivitiesHistoryPaginationQuery request, CancellationToken cancellationToken) =>
        await _activityService.GetAllAsync(true, request.Page, request.Count);
}
