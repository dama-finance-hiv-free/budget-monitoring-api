using System;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class OutlayOption : RunnerVm
{
    public string User { get; set; }
    public string Project { get; set; }
    public string RegionDescription { get; set; }
    public DateTime MonthStartDate { get; set; }
    public DateTime MonthEndDate { get; set; }
    public DateTime ComponentStartDate { get; set; }
    public DateTime ComponentEndDate { get; set; }
}