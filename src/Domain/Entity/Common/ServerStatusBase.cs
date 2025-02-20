using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Common;

public class ServerStatusBase : ITenant
{
    public string Tenant { get; set; }
    public string Region { get; set; }
    public string Runner { get; set; }
    public string CopYear { get; set; }
    public string DayStatus { get; set; }
    public string Batch { get; set; }
}