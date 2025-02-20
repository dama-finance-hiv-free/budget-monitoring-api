using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearCostCategory.Queries;

public class CopYearCostCategoryCountQueryHandler : RequestHandlerBase, IRequestHandler<CopYearCostCategoryCountQuery, int>
{
    private readonly ICopYearCostCategoryService _copYearCostCategoryService;

    public CopYearCostCategoryCountQueryHandler(ICopYearCostCategoryService copYearCostCategoryService)
    {
        _copYearCostCategoryService = copYearCostCategoryService;
    }

    public async Task<int> Handle(CopYearCostCategoryCountQuery request, CancellationToken cancellationToken) =>
        await _copYearCostCategoryService.GetCount(true);

}