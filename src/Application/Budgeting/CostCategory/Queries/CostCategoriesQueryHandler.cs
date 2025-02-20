using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CostCategory.Queries;

public class CostCategoriesQueryHandler : RequestHandlerBase, IRequestHandler<CostCategoriesQuery, CostCategoryVm[]>
{
    private readonly ICostCategoryService _costCategoryService;

    public CostCategoriesQueryHandler(ICostCategoryService costCategoryService)
    {
        _costCategoryService = costCategoryService;
    }

    public async Task<CostCategoryVm[]> Handle(CostCategoriesQuery request, CancellationToken cancellationToken) => 
        await _costCategoryService.GetAllAsync(true);
}
