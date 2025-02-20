using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Queries;

public class BudgetDashboardQuery : IRequest<BudgetDashboardVm>
{
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string Component { get; set; }
    public string Region { get; set; }
    public string Period { get; set; }
}