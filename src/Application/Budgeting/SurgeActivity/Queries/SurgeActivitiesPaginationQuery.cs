using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SurgeActivity.Queries;

public class SurgeActivitiesPaginationQuery : IRequest<SurgeActivityVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}