using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.Role.Commands;

public class RoleCommandResponse : BaseResponse
{
    public RoleVm Data { get; set; }
}