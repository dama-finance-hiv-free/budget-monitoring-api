using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Outlay.Commands;

public class OutlayCommandResponse : BaseResponse
{
    public OutlayVm Data { get; set; }
}