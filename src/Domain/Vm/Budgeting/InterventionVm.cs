using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class InterventionVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string BudgetCode { get; set; }
    public double Percentage { get; set; }
    public DateTime CreatedOn { get; set; }
}