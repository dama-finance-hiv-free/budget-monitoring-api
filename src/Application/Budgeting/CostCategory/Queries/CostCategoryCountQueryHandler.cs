using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CostCategory.Queries;

public class CostCategoryCountQueryHandler : RequestHandlerBase, IRequestHandler<CostCategoryCountQuery, int>
{
    private readonly ICostCategoryService _costCategoryService;

    public CostCategoryCountQueryHandler(ICostCategoryService costCategoryService)
    {
        _costCategoryService = costCategoryService;
    }

    public async Task<int> Handle(CostCategoryCountQuery request, CancellationToken cancellationToken) =>
        await _costCategoryService.GetCount(true);
}