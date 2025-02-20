using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearBudgetCode.Queries;

public class CopYearBudgetCodesQueryHandler : RequestHandlerBase, IRequestHandler<CopYearBudgetCodesQuery, CopYearBudgetCodeVm[]>
{
    private readonly ICopYearBudgetCodeService _copYearBudgetCodeService;

    public CopYearBudgetCodesQueryHandler(ICopYearBudgetCodeService copYearBudgetCodeService)
    {
        _copYearBudgetCodeService = copYearBudgetCodeService;
    }

    public async Task<CopYearBudgetCodeVm[]> Handle(CopYearBudgetCodesQuery request, CancellationToken cancellationToken) => 
        await _copYearBudgetCodeService.GetAllAsync(true);

}
