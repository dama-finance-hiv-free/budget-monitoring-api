using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Queries;

public class ActivityPlanQuery : IRequest<ActivityPlanVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string CopYear { get; set; }
    public string Component { get; set; }
    public string Project { get; set; }
    public string Description { get; set; }
    public string Intervention { get; set; }
    public string CostCategory { get; set; }
    public string Approach { get; set; }
    public string Objective { get; set; }
    public string BudgetCode { get; set; }
    public double BudgetBalance { get; set; }
    public string ActivityType { get; set; }
    public DateTime CreatedOn { get; set; }
}