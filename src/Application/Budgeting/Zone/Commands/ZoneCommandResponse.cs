using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Zone.Commands;

public class ZoneCommandResponse : BaseResponse
{
    public ZoneVm Data { get; set; }
}