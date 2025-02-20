using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.BranchStation.Commands;

public class BranchStationCommandResponse : BaseResponse
{
    public BranchStationVm Data { get; set; }
}