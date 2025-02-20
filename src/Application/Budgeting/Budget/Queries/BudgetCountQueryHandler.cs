using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Queries;

public class BudgetCountQueryHandler : RequestHandlerBase, IRequestHandler<BudgetCountQuery, int>
{
    private readonly IBudgetService _budgetService;

    public BudgetCountQueryHandler(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    public async Task<int> Handle(BudgetCountQuery request, CancellationToken cancellationToken) =>
        await _budgetService.GetCount(true);
}