using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class RoleMenuDto : IEntityBase
{
    public string Tenant { get; set; }
    public string Role { get; set; }
    public string[] MenuCodes { get; set; }
}