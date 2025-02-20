using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.ServerStatus.Commands;

public abstract class ServerStatusCommand : IRequest<ServerStatusCommandResponse>
{
    public ServerStatusVm ServerStatus { get; set; }
}