using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivitiesHistoryPaginationQuery : IRequest<ActivityVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}