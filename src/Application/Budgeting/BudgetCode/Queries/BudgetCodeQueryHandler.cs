using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetCode.Queries;

public class BudgetCodeQueryHandler : RequestHandlerBase, IRequestHandler<BudgetCodeQuery, BudgetCodeVm>
{
    private readonly IBudgetCodeService _budgetCodeService;

    public BudgetCodeQueryHandler(IBudgetCodeService budgetCodeService)
    {
        _budgetCodeService = budgetCodeService;
    }

    public async Task<BudgetCodeVm> Handle(BudgetCodeQuery request, CancellationToken cancellationToken) =>
        await _budgetCodeService.GetAsync(request.Tenant, request.CopYear);
}