using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Queries;

public class MilestonesPaginationQuery : IRequest<MilestoneVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}