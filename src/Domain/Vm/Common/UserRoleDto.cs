using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class UserRoleDto : IEntityBase
{
    public string Tenant { get; set; }
    public string User { get; set; }
    public string[] Roles { get; set; }
}