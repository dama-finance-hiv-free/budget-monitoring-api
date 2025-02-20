using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Commands;

public abstract class ActivityCommand : IRequest<ActivityCommandResponse>
{
    public ActivityVm Activity { get; set; }
    public string Tenant { get; set; }
    public string CurrentUser { get; set; }
}