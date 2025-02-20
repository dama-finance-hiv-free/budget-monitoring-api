using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Queries;

public class SurgeActivityPlansQuery : IRequest<ActivityPlanVm[]>
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Component { get; set; }
    public string Project { get; set; }
}