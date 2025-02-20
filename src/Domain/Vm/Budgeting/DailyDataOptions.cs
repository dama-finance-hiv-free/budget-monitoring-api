using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class DailyDataOptions : IEntityBase
{
    public string CurrentUser { get; set; }
    public string Branch { get; set; }
}
