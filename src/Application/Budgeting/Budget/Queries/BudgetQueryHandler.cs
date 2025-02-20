using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Queries;

public class BudgetQueryHandler : RequestHandlerBase, IRequestHandler<BudgetQuery, BudgetVm>
{
    private readonly IBudgetService _budgetService;

    public BudgetQueryHandler(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    public async Task<BudgetVm> Handle(BudgetQuery request, CancellationToken cancellationToken) =>
        await _budgetService.GetAsync(request.Tenant, request.CopYear);
}