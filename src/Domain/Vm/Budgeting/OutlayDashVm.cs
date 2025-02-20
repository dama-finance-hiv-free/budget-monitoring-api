using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class OutlayDashVm : IEntityBase
{
    public string Component { get; set; }
    public string Outlay { get; set; }
    public string BudgetCode { get; set; }
    public string Indicator { get; set; }
    public double AnnualTarget { get; set; }
    public double ComponentTarget { get; set; }
    public double PeriodTarget { get; set; }
    public double PeriodAchievement { get; set; }
    public double PercentageAchievement { get; set; }
    public double ComponentBudget { get; set; }
    public double PeriodBudget { get; set; }
    public double PeriodExpenditure { get; set; }
    public double PercentageExpenditure { get; set; }
}