using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Common;

public class UserBranch : ITenant
{
    public string Tenant { get; set; }
    public string UsrCode { get; set; }
    public string BranchCode { get; set; }
    public string IsDefault { get; set; }
}