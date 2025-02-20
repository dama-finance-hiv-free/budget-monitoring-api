using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearBudgetCode.Queries;

public class CopYearBudgetCodeQueryHandler : RequestHandlerBase, IRequestHandler<CopYearBudgetCodeQuery, CopYearBudgetCodeVm>
{
    private readonly ICopYearBudgetCodeService _copYearBudgetCodeService;

    public CopYearBudgetCodeQueryHandler(ICopYearBudgetCodeService copYearBudgetCodeService)
    {
        _copYearBudgetCodeService = copYearBudgetCodeService;
    }

    public async Task<CopYearBudgetCodeVm> Handle(CopYearBudgetCodeQuery request, CancellationToken cancellationToken) =>
        await _copYearBudgetCodeService.GetAsync(request.Tenant, request.BudgetCode);
}