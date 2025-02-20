using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class UserBranchVm : IEntityBase
{
    public string Tenant { get; set; }
    public string UsrCode { get; set; }
    public string BranchCode { get; set; }
    public string IsDefault { get; set; }
}