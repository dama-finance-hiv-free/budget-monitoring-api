using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting
{
    public class WeekVm: IEntityBase
    {
        public int WeekSerial { get; set; }
        public int WeekSerialAdjusted { get; set; }
        public DateTime WeekStartDate { get; set; }
        public DateTime WeekEndDate { get; set; }
    }
}
