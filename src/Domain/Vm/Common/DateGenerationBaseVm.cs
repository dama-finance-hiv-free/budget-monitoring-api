using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class DateGenerationBaseVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Branch { get; set; }
    public DateTime TransDate { get; set; }
    public string TransMonth { get; set; }
    public string TransYear { get; set; }
    public string TransDay { get; set; }
    public DateTime PrevDay { get; set; }
    public DateTime WeekStart { get; set; }
    public DateTime WeekEnd { get; set; }
    public DateTime MonthStart { get; set; }
    public DateTime MonthEnd { get; set; }
    public DateTime LastTransDate { get; set; }
}