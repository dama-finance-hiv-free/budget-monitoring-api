using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.ServerStatus.Commands;

public class ServerStatusCommandResponse : BaseResponse
{
    public ServerStatusVm Data { get; set; }
}