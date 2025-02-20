using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CostCategory.Queries;

public class CostCategoriesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<CostCategoriesPaginationQuery, CostCategoryVm[]>
{
    private readonly ICostCategoryService _costCategoryService;

    public CostCategoriesPaginationQueryHandler(ICostCategoryService costCategoryService)
    {
        _costCategoryService = costCategoryService;
    }

    public async Task<CostCategoryVm[]> Handle(CostCategoriesPaginationQuery request, CancellationToken cancellationToken) =>
        await _costCategoryService.GetAllAsync(true, request.Page, request.Count);
}
