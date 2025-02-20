using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.SystemMenu.Commands;

public class SystemMenuCommandResponse : BaseResponse
{
    public SystemMenuVm Data { get; set; }
}