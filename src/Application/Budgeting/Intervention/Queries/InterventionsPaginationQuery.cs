using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Intervention.Queries;

public class InterventionsPaginationQuery : IRequest<InterventionVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}