using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class UserBranchDto : IEntityBase
{
    public string Tenant { get; set; }
    public string User { get; set; }
    public string[] Branches { get; set; }
}