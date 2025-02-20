using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.BranchStation.Commands;

public abstract class BranchStationCommand : IRequest<BranchStationCommandResponse>
{
    public BranchStationVm BranchStation { get; set; }
}