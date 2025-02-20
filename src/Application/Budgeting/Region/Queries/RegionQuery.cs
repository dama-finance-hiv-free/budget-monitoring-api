using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Region.Queries;

public class RegionQuery : IRequest<RegionVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
}