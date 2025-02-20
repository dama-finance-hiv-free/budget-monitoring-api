using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Common;

public class BranchStation : ITenant
{
    public string Tenant { get; set; }

    public string Branch { get; set; }

    public string Station { get; set; }

    public string Status { get; set; }

    public DateTime CreatedOn { get; set; }
}