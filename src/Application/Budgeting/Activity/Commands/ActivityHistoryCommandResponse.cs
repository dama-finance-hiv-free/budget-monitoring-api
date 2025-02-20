using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Activity.Commands;

public class ActivityHistoryCommandResponse : BaseResponse
{
    public ActivityVm Data { get; set; }
}