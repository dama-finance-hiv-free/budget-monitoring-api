using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class CopYearOutlayVm : IEntityBase
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string Outlay { get; set; }
}