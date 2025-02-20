using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.UserMenu.Commands;

public abstract class UserRoleCommand : IRequest<UserRoleCommandResponse>
{
    public UserRoleDto UserRoles { get; set; }
}