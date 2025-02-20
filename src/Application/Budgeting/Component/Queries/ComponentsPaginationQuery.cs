using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Component.Queries;

public class ComponentsPaginationQuery : IRequest<ComponentVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}