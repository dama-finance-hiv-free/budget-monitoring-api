using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Queries;

public class BudgetSummaryBatchQueryHandler : RequestHandlerBase, IRequestHandler<BudgetSummaryBatchQuery, BudgetSummaryBatchVm>
{
    private readonly IBudgetPersistence _budgetPersistence;

    public BudgetSummaryBatchQueryHandler(IBudgetPersistence budgetPersistence)
    {
        _budgetPersistence = budgetPersistence;
    }

    public async Task<BudgetSummaryBatchVm> Handle(BudgetSummaryBatchQuery request, CancellationToken cancellationToken) =>
        await _budgetPersistence.GetBudgetSummaryBatchAsync(request.Project, request.Component);
}