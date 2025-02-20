using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class UserRoleVm : IEntityBase
{
    public string Tenant { get; set; }
    public string RoleCode { get; set; }
    public string UsrCode { get; set; }
    public string Status { get; set; }
}

public class RoleUsersVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Role { get; set; }
    public string Users { get; set; }
}