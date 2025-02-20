using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class CopYearCostCategory : ITenant
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string CostCategory { get; set; }
}