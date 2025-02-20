using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.UserMenu.Commands;

public class UserRoleCommandResponse : BaseResponse
{
    public UserRoleDto Data { get; set; }
    public UserRoleVm[] UserRoles { get; set; }
}