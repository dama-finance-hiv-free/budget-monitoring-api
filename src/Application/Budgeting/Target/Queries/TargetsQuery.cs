using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Target.Queries;

public class TargetsQuery : IRequest<TargetVm[]>
{
    public string Tenant { get; set; }
    public string Region { get; set; }
}
