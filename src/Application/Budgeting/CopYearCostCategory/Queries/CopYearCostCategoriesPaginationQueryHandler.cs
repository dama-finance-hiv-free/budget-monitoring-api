using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearCostCategory.Queries;

public class CopYearCostCategoriesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<CopYearCostCategoriesPaginationQuery, CopYearCostCategoryVm[]>
{
    private readonly ICopYearCostCategoryService _copYearCostCategoryService;

    public CopYearCostCategoriesPaginationQueryHandler(ICopYearCostCategoryService copYearCostCategoryService)
    {
        _copYearCostCategoryService = copYearCostCategoryService;
    }

    public async Task<CopYearCostCategoryVm[]> Handle(CopYearCostCategoriesPaginationQuery request, CancellationToken cancellationToken) =>
        await _copYearCostCategoryService.GetAllAsync(true, request.Page, request.Count);

}
