using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Queries;

public class MilestoneDashQuery : IRequest<ChartVm>
{
    public string Tenant { get; set; }
    public string Region { get; set; }
    public string Project { get; set; }
    public string Component { get; set; }
}