using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Queries;

public class BudgetDashboardQueryHandler : RequestHandlerBase, IRequestHandler<BudgetDashboardQuery, BudgetDashboardVm>
{
    private readonly IBudgetPersistence _budgetPersistence;

    public BudgetDashboardQueryHandler(IBudgetPersistence budgetPersistence)
    {
        _budgetPersistence = budgetPersistence;
    }

    public async Task<BudgetDashboardVm> Handle(BudgetDashboardQuery request, CancellationToken cancellationToken) =>
        await _budgetPersistence.GetBudgetDashboardAsync(request.Project, request.Component, request.Region, request.Period);
}