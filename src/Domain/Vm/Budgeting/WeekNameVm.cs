using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class WeekNameVm : IEntityBase
{
    public string Code { get; set; }
    public string Description { get; set; }
}