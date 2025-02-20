using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class OutlayAnalysisOptions : IEntityBase
{
    public string Tenant { get; set; }
    public string Region { get; set; }
    public string Component { get; set; }
    public string DashboardType { get; set; }
}