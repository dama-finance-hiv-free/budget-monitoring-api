using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Common;

public class RoleMenu : ITenant
{
    public string Tenant { get; set; }
    public string MenuCode { get; set; }
    public string RoleCode { get; set; }
    public string App { get; set; }
    public string Status { get; set; }
    public DateTime CreatedOn { get; set; }
}