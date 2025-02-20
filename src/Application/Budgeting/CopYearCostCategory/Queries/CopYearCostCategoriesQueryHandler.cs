using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearCostCategory.Queries;

public class CopYearCostCategoriesQueryHandler : RequestHandlerBase, IRequestHandler<CopYearCostCategoriesQuery, CopYearCostCategoryVm[]>
{
    private readonly ICopYearCostCategoryService _copYearCostCategoryService;

    public CopYearCostCategoriesQueryHandler(ICopYearCostCategoryService copYearCostCategoryService)
    {
        _copYearCostCategoryService = copYearCostCategoryService;
    }

    public async Task<CopYearCostCategoryVm[]> Handle(CopYearCostCategoriesQuery request, CancellationToken cancellationToken) => 
        await _copYearCostCategoryService.GetAllAsync(true);

}
