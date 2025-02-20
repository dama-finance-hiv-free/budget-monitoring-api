using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Intervention.Queries;

public class InterventionQuery : IRequest<InterventionVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string CopYear { get; set; }
    public string Description { get; set; }
    public string BudgetCode { get; set; }
    public string Project { get; set; }
    public double Percentage { get; set; }
    public DateTime CreatedOn { get; set; }
}