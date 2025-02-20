using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearBudgetCode.Queries;

public class CopYearBudgetCodeCountQueryHandler : RequestHandlerBase, IRequestHandler<CopYearBudgetCodeCountQuery, int>
{
    private readonly ICopYearBudgetCodeService _copYearBudgetCodeService;

    public CopYearBudgetCodeCountQueryHandler(ICopYearBudgetCodeService copYearBudgetCodeService)
    {
        _copYearBudgetCodeService = copYearBudgetCodeService;
    }

    public async Task<int> Handle(CopYearBudgetCodeCountQuery request, CancellationToken cancellationToken) =>
        await _copYearBudgetCodeService.GetCount(true);
}