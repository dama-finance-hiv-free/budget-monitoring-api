using System;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class DailyDataVm
{
    public string User { get; set; }
    public string UserCode { get; set; }
    public string Site { get; set; }
    public string SiteName { get; set; }
    public string UserName { get; set; }
    public double PreviousReceipts { get; set; }
    public double TodayReceipts { get; set; }
    public double TotalReceipts { get; set; }
    public DateTime TransDate { get; set; }
}