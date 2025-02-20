using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Privilege.Commands;

public abstract class PrivilegeCommand : IRequest<PrivilegeCommandResponse>
{
    public PrivilegeVm Privilege { get; set; }
}