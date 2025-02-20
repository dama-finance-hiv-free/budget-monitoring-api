using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Zone.Queries;

public class ZonesPaginationQuery : IRequest<ZoneVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}