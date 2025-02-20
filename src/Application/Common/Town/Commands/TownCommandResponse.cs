using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.Town.Commands;

public class TownCommandResponse : BaseResponse
{
    public TownVm Data { get; set; }
}