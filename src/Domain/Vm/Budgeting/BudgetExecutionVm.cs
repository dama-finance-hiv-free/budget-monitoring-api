using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class BudgetExecutionVm : IEntityBase
{
    public string User { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string Region { get; set; }
    public string Zone { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public double Budgeted { get; set; }
    public double Accumulated { get; set; }
    public double Actual { get; set; }
    public double Balance { get; set; }
}