using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Component.Commands;

public abstract class ComponentCommand : IRequest<ComponentCommandResponse>
{
    public ComponentVm Component { get; set; }
}