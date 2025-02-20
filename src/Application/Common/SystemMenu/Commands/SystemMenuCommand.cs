using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.SystemMenu.Commands;

public abstract class SystemMenuCommand : IRequest<SystemMenuCommandResponse>
{
    public SystemMenuVm SystemMenu { get; set; }
}