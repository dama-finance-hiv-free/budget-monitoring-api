using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivitiesQuery : IRequest<ActivityVm[]>
{
    public string Tenant { get; set; }
    public string ActivityType { get; set; }
    public string Region { get; set; }
    public string Branch { get; set; }
    public string Project { get; set; }
}