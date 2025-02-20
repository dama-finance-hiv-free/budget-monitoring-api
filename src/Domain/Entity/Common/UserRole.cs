using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Common;

public class UserRole : ITenant
{
    public string Tenant { get; set; }
    public string RoleCode { get; set; }
    public string UsrCode { get; set; }
    public string Status { get; set; }

}