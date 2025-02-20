namespace Dama.Fin.Domain.Vm.Budgeting
{
    public class OutlayBaseVm
    {
        public string Tenant { get; set; }
        public string Code { get; set; }
        public string User { get; set; }
        public string Period { get; set; }
        public string InterventionName { get; set; }
        public string CostCategoryName { get; set; }
        public string BudgetCode { get; set; }
        public string BudgetCodeDescription { get; set; }
        public float BudgetAmount { get; set; }
        public float ComponentExpenditure { get; set; }
        public float ComponentBudget { get; set; }
        public float ComponentVariance { get; set; }
        public float ComponentPercentage { get; set; }
        public float MonthExpenditure { get; set; }
        public float MonthBudget { get; set; }
        public float MonthVariance { get; set; }
        public float MonthPercentage { get; set; }
        public float WeekExpenditure { get; set; }
        public float WeekBudget { get; set; }
        public float WeekVariance { get; set; }
        public float WeekPercentage { get; set; }
    }
}