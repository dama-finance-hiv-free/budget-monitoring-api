using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class IncludeRunnerVm : IEntityBase
{
    public string User { get; set; }
    public string Runner { get; set; }
}