using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayAnalysisQuery : IRequest<OutlayDashVm[]>
{
    public string Tenant { get; set; }
    public string Region { get; set; }
    public string DashboardType { get; set; }
    public string Component { get; set; }
}