using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivitiesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<ActivitiesPaginationQuery, ActivityVm[]>
{
    private readonly IActivityService _activityService;

    public ActivitiesPaginationQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<ActivityVm[]> Handle(ActivitiesPaginationQuery request, CancellationToken cancellationToken) =>
        await _activityService.GetAllAsync(true, request.Page, request.Count);
}
