using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Queries;

public class BudgetSummaryBatchQuery : IRequest<BudgetSummaryBatchVm>
{
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string Component { get; set; }
}