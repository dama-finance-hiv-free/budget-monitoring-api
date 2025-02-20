using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class UserMenuVm : IEntityBase
{
    public string App { get; set; }
    public string UsrCode { get; set; }
    public string Language { get; set; }
    public string MenCode { get; set; }
    public string MenDescription { get; set; }
    public string Status { get; set; }
}