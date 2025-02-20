using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Target.Commands;

public abstract class TargetCommand : IRequest<TargetCommandResponse>
{
    public TargetVm Target { get; set; }
}