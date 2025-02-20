using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayDashQuery : IRequest<OutlayDashVm[]>
{
    public string Tenant { get; set; }
    public string Region { get; set; }
}