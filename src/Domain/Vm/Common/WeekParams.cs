using System;

namespace Dama.Fin.Domain.Vm.Common;

public class WeekParams
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string CopYear { get; set; }
}