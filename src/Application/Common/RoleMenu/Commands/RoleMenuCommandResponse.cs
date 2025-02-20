using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.RoleMenu.Commands;

public class RoleMenuCommandResponse : BaseResponse
{
    public RoleMenuDto Data { get; set; }
}