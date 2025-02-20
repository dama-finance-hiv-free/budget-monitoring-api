using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Commands;

public abstract class ActivityPlanCommand : IRequest<ActivityPlanCommandResponse>
{
    public ActivityPlanVm ActivityPlan { get; set; }
}