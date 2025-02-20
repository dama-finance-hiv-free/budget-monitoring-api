using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.UserMenu.Commands;

public class EditRoleUsersCommand : UserRoleCommand
{
    public RoleUsersVm RoleUsers { get; set; }
}