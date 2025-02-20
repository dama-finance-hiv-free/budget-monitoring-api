using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetCode.Queries;

public class BudgetCodeQuery : IRequest<BudgetCodeVm>
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string Region { get; set; }
    public string Activity { get; set; }
    public string Component { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedOn { get; set; }
}