using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearCostCategory.Queries;

public class CopYearCostCategoryQueryHandler : RequestHandlerBase, IRequestHandler<CopYearCostCategoryQuery, CopYearCostCategoryVm>
{
    private readonly ICopYearCostCategoryService _copYearCostCategoryService;

    public CopYearCostCategoryQueryHandler(ICopYearCostCategoryService copYearCostCategoryService)
    {
        _copYearCostCategoryService = copYearCostCategoryService;
    }

    public async Task<CopYearCostCategoryVm> Handle(CopYearCostCategoryQuery request, CancellationToken cancellationToken) =>
        await _copYearCostCategoryService.GetAsync(request.Tenant, request.CopYear);

}