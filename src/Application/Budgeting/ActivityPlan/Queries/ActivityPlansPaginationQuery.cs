using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Queries;

public class ActivityPlansPaginationQuery : IRequest<ActivityPlanVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}