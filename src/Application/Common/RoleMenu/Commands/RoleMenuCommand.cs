using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.RoleMenu.Commands;

public abstract class RoleMenuCommand : IRequest<RoleMenuCommandResponse>
{
    public RoleMenuDto RoleMenus { get; set; }
}