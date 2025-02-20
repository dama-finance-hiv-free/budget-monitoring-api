using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class ActivityVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Batch { get; set; }
    public string BatchLine { get; set; }
    public string Runner { get; set; }
    public string Component { get; set; }
    public string Branch { get; set; }
    public string UserCode { get; set; }
    public DateTime TransDate { get; set; }
    public string Description { get; set; }
    public string Activity { get; set; }
    public string Site { get; set; }
    public string CostCategory { get; set; }
    public string Intervention { get; set; }
    public string BudgetCode { get; set; }
    public string Strategy { get; set; }
    public double Amount { get; set; }
    public string ActivityType { get; set; }
    public string TranCode { get; set; }
    public string Project { get; set; }
    public string CopYear { get; set; }
    public string Region { get; set; }
    public DateTime ServerDate { get; set; }
}