using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class OutlayAnalysisVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string BudgetCode { get; set; }
    public string Indicator { get; set; }
    public string Type { get; set; }
    public double Target { get; set; }
    public double PeriodTarget { get; set; }
    public double PeriodAchievement { get; set; }
    public double PercentageAchievement { get; set; }
    public double Budget { get; set; }
    public double PeriodBudget { get; set; }
    public double PeriodExpenditure { get; set; }
    public double PercentageExpenditure { get; set; }
}