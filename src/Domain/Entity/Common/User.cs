using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Common;

public partial class User : ITenant
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string UsrName { get; set; }
    public string Connected { get; set; }
    public string Computer { get; set; }
    public string LogTime { get; set; }
    public string DeviceSerial { get; set; }
    public string UsrHash { get; set; }
    public string PhotoUrl { get; set; }
}