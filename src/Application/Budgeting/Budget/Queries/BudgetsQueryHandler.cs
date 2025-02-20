using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Queries;

public class BudgetsQueryHandler : RequestHandlerBase, IRequestHandler<BudgetsQuery, BudgetVm[]>
{
    private readonly IBudgetService _budgetService;

    public BudgetsQueryHandler(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    public async Task<BudgetVm[]> Handle(BudgetsQuery request, CancellationToken cancellationToken) => 
        await _budgetService.GetAllAsync(true);
}
