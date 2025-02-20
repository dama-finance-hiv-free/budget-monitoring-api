using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearBudgetCode.Queries;

public class CopYearBudgetCodesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<CopYearBudgetCodesPaginationQuery, CopYearBudgetCodeVm[]>
{
    private readonly ICopYearBudgetCodeService _copYearBudgetCodeService;

    public CopYearBudgetCodesPaginationQueryHandler(ICopYearBudgetCodeService copYearBudgetCodeService)
    {
        _copYearBudgetCodeService = copYearBudgetCodeService;
    }

    public async Task<CopYearBudgetCodeVm[]> Handle(CopYearBudgetCodesPaginationQuery request, CancellationToken cancellationToken) =>
        await _copYearBudgetCodeService.GetAllAsync(true, request.Page, request.Count);

}
