using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Vm.Batch;

namespace Dama.Fin.Domain.Vm.Common;

public class LoginVm : IEntityBase
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public LoginStatus Status { get; set; }
    public SessionBatchVm SessionBatch { get; set; }
    public Device DeviceInfo { get; set; }
    public string Lang { get; set; }
}

public class Device : IEntityBase
{
    public string NetBiosName { get; set; }
    public string DeviceSerial { get; set; }
}