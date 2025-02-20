using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivityJournalHistoryQueryHandler : RequestHandlerBase,
    IRequestHandler<ActivityJournalHistoryQuery, ActivityVm>
{
    private readonly IActivityService _activityService;

    public ActivityJournalHistoryQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<ActivityVm> Handle(ActivityJournalHistoryQuery request, CancellationToken cancellationToken) =>
        await _activityService.GetAsync(request.Tenant, request.Batch);
}