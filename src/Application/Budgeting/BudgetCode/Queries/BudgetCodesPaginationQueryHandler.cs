using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetCode.Queries;

public class BudgetCodesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<BudgetCodesPaginationQuery, BudgetCodeVm[]>
{
    private readonly IBudgetCodeService _budgetcodeService;

    public BudgetCodesPaginationQueryHandler(IBudgetCodeService budgetcodeService)
    {
        _budgetcodeService = budgetcodeService;
    }

    public async Task<BudgetCodeVm[]> Handle(BudgetCodesPaginationQuery request, CancellationToken cancellationToken) =>
        await _budgetcodeService.GetAllAsync(true, request.Page, request.Count);
}
