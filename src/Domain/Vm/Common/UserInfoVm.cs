using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class UserInfoVm : IEntityBase
{
    public string Code { get; set; }
    public string UsrName { get; set; }
    public string PhotoUrl { get; set; }
}