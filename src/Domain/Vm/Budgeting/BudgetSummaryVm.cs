namespace Dama.Fin.Domain.Vm.Budgeting;

public class BudgetSummaryVm
{
    public string Code { get; set; }
    public string Description { get; set; }
    public double AmountUsd { get; set; }
    public double AmountCfa { get; set; }
}

public class BudgetSummaryBatchVm
{
    public BudgetSummaryVm[] Interventions { get; set; }
    public BudgetSummaryVm[] BudgetCodes { get; set; }
    public BudgetSummaryVm[] CostCategories { get; set; }
}

public class BudgetDashboardVm
{
    public BudgetSummaryVm[] AnnualBudgets { get; set; }
    public BudgetSummaryVm[] ComponentBudgets { get; set; }
    public BudgetSummaryVm[] RegionExpenditures { get; set; }
    public BudgetSummaryVm[] TotalExpenditures { get; set; }
    public BudgetSummaryVm[] Interventions { get; set; }
    public BudgetSummaryVm[] CostCategories { get; set; }
}