using System;

namespace Dama.Fin.Domain.Vm.Common;

public class ServerStatusHistoryVm : ServerStatusBaseVm
{
    public DateTime? TransDate { get; set; }
    public string YearStatus { get; set; }
}