using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Commands;

public abstract class ActivityHistoryCommand : IRequest<ActivityCommandResponse>
{
    public ActivityVm ActivityHistory { get; set; }
}