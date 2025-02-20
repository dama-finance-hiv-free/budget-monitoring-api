using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class CostCategory : ITenant
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string CopYear { get; set; }
    public string Description { get; set; }
    public string Project { get; set; }
    public DateTime CreatedOn { get; set; }
}