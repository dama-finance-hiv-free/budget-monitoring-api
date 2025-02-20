using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivityJournalHistoryCountQueryHandler : RequestHandlerBase,
    IRequestHandler<ActivityJournalHistoryCountQuery, int>
{
    private readonly IActivityService _activityService;

    public ActivityJournalHistoryCountQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<int> Handle(ActivityJournalHistoryCountQuery request, CancellationToken cancellationToken) =>
        await _activityService.GetCount(true);
}