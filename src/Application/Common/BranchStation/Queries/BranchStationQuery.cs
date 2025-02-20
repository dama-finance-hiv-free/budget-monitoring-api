using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.BranchStation.Queries;

public class BranchStationQuery : IRequest<BranchStationVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
}