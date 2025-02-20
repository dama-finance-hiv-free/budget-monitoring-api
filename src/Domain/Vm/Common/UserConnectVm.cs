using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Common;

public class UserConnectVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string NetBiosName { get; set; }
    public string DeviceSerial { get; set; }
    public string Lang { get; set; }
    public string Branch { get; set; }
}