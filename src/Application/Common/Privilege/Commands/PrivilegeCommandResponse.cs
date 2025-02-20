using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.Privilege.Commands;

public class PrivilegeCommandResponse : BaseResponse
{
    public PrivilegeVm Data { get; set; }
}