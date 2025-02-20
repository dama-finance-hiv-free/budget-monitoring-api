using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class RegionVm : IEntityBase
{
    public string Code { get; set; }
    public string Zone { get; set; }
    public string Initial { get; set; }
    public string Description { get; set; }
}