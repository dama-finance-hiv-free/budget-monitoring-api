using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class BudgetVm : IEntityBase
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string Region { get; set; }
    public string Activity { get; set; }
    public string Component { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedOn { get; set; }
}