using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Role.Commands;

public abstract class RoleCommand : IRequest<RoleCommandResponse>
{
    public RoleVm Role { get; set; }
}