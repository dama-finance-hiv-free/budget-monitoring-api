using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetExecution.Queries;

public class BudgetExecutionQueryHandler : RequestHandlerBase,
    IRequestHandler<BudgetExecutionQuery, BudgetExecutionVm[]>
{
    private readonly IBudgetExecutionService _budgetExecutionService;

    public BudgetExecutionQueryHandler(IBudgetExecutionService budgetExecutionService)
    {
        _budgetExecutionService = budgetExecutionService;
    }

    public async Task<BudgetExecutionVm[]> Handle(BudgetExecutionQuery request,
        CancellationToken cancellationToken) =>
        await _budgetExecutionService.GetBudgetExecutionsAsync(request.Options);
}
