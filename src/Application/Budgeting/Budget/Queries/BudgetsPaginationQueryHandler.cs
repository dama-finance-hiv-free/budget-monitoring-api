using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Queries;

public class BudgetsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<BudgetsPaginationQuery, BudgetVm[]>
{
    private readonly IBudgetService _budgetCodeService;

    public BudgetsPaginationQueryHandler(IBudgetService budgetCodeService)
    {
        _budgetCodeService = budgetCodeService;
    }

    public async Task<BudgetVm[]> Handle(BudgetsPaginationQuery request, CancellationToken cancellationToken) =>
        await _budgetCodeService.GetAllAsync(true, request.Page, request.Count);
}
