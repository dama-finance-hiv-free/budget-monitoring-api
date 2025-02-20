using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivitiesHistoryQueryHandler : RequestHandlerBase, IRequestHandler<ActivitiesHistoryQuery, ActivityVm[]>
{
    private readonly IActivityService _activityService;

    public ActivitiesHistoryQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<ActivityVm[]> Handle(ActivitiesHistoryQuery request, CancellationToken cancellationToken) => 
        await _activityService.GetAllAsync(true);
}
