using System;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class OutlayDashboardBaseVm
{
    public DateTime WeekStartDate { get; set; }
    public DateTime WeekEndDate { get; set; }
    public DateTime MonthStartDate { get; set; }
    public DateTime MonthEndDate { get; set; }
    public DateTime ComponentStartDate { get; set; }
    public DateTime ComponentEndDate { get; set; }
}
