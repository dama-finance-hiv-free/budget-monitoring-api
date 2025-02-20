using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Target.Queries;

public class TargetsPaginationQuery : IRequest<TargetVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}