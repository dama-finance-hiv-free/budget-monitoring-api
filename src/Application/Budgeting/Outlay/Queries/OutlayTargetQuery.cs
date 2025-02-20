using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayTargetQuery : IRequest<OutlayDashVm[]>
{
    public string Tenant { get; set; }
    public string Region { get; set; }
}