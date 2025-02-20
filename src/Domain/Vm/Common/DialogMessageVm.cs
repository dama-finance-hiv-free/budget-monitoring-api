using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class DialogMessageVm : IEntityBase
{
    public string Code { get; set; }
    public string Lid { get; set; }
    public string Description { get; set; }
}