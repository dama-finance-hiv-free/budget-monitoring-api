using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class ActivityPlanBase : ITenant
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string Project { get; set; }
    public string CopYear { get; set; }
    public string Description { get; set; }
    public string Intervention { get; set; }
    public string CostCategory { get; set; }
    public string BudgetCode { get; set; }
    public string Strategy { get; set; }
    public string ActivityType { get; set; }
    public DateTime CreatedOn { get; set; }
}