using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class ActivityScheduleReportVm : IEntityBase
{
    public ActivityScheduleBudgetVm[] ActivityScheduleBudget { get; set; }
    public WeekNameVm[] Weeks { get; set; }
    public string SiteName { get; set; }
    public string MonthName { get; set; }
}