namespace Dama.Fin.Domain.Vm.Common;

public class ServerStatusVm : ServerStatusBaseVm
{
    public string SysTrans { get; set; }
    public string DayStatus { get; set; }
    public string CashTrans { get; set; }
    public bool BackOfficeOnly { get; set; }
    public bool StateWorkSystem => SysTrans == "50" && DayStatus == "01";
    public bool StateCashSystem => CashTrans == "50";
}