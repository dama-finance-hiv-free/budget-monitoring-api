using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetCode.Queries;

public class BudgetCodesQueryHandler : RequestHandlerBase, IRequestHandler<BudgetCodesQuery, BudgetCodeVm[]>
{
    private readonly IBudgetCodeService _budgetCodeService;

    public BudgetCodesQueryHandler(IBudgetCodeService budgetCodeService)
    {
        _budgetCodeService = budgetCodeService;
    }

    public async Task<BudgetCodeVm[]> Handle(BudgetCodesQuery request, CancellationToken cancellationToken) => 
        await _budgetCodeService.GetAllAsync(true);
}
