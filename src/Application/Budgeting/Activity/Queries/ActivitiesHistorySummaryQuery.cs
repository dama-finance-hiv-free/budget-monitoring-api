using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivitiesHistorySummaryQuery : IRequest<ActivityVm[]>
{
    public ActivityHistoryOptionsVm Options;
}
