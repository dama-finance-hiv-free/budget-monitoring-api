using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetExecution.Queries;

public class BudgetExecutionQuery : IRequest<BudgetExecutionVm[]>
{
    public BudgetAnalysisOptions Options { get; set; }
}