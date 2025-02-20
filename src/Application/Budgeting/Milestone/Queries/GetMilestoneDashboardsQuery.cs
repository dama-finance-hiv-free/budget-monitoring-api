using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Queries;

public class GetMilestoneDashboardsQuery : IRequest<MilestoneDashboardVm[]>
{
    public MilestoneDasboardOptions Options { get; set; }
}