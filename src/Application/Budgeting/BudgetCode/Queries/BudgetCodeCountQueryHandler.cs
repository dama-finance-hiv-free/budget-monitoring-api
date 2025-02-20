using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetCode.Queries;

public class BudgetCodeCountQueryHandler : RequestHandlerBase, IRequestHandler<BudgetCodeCountQuery, int>
{
    private readonly IBudgetCodeService _budgetCodeService;

    public BudgetCodeCountQueryHandler(IBudgetCodeService budgetCodeService)
    {
        _budgetCodeService = budgetCodeService;
    }

    public async Task<int> Handle(BudgetCodeCountQuery request, CancellationToken cancellationToken) =>
        await _budgetCodeService.GetCount(true);
}