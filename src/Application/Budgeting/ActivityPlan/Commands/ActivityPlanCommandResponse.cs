using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Commands;

public class ActivityPlanCommandResponse : BaseResponse
{
    public ActivityPlanVm Data { get; set; }
}