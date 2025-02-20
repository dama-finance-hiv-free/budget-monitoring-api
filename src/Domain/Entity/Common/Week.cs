using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Common;

public class Week: ITenant
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public int WeekSerial { get; set; }
    public int WeekSerialAdjusted { get; set; }
    public DateTime WeekStartDate { get; set; }
    public DateTime WeekEndDate { get; set; }
    public string Component { get; set; }
    public int ComponentWeekSerial { get; set; }
}