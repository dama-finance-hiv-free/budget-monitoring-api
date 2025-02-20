using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CostCategory.Queries;

public class CostCategoryQueryHandler : RequestHandlerBase, IRequestHandler<CostCategoryQuery, CostCategoryVm>
{
    private readonly ICostCategoryService _costCategoryService;

    public CostCategoryQueryHandler(ICostCategoryService costCategoryService)
    {
        _costCategoryService = costCategoryService;
    }

    public async Task<CostCategoryVm> Handle(CostCategoryQuery request, CancellationToken cancellationToken) =>
        await _costCategoryService.GetAsync(request.Tenant, request.Code);
}