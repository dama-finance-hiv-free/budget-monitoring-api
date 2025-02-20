using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.CostCategory;

public class CostCategoryService : ServiceBase<Domain.Entity.Budgeting.CostCategory, CostCategoryVm>, ICostCategoryService
{
    private readonly ICostCategoryPersistence _costCategoryPersistence;

    public CostCategoryService(IDataPersistence<Domain.Entity.Budgeting.CostCategory> persistence, IMapper mapper, IDistributedCache cache, ICostCategoryPersistence costCategoryPersistence) : base(persistence, mapper, cache)
    {
        _costCategoryPersistence = costCategoryPersistence;
    }

    public async Task<CostCategoryVm[]> GetCostCategoriesAsync(string tenant)
        => await GetCachedItemsAsync(() => _costCategoryPersistence.GetCostCategoriesAsync(tenant));


    public async Task<string[]> GetCostCategoryCodesAsync(string tenant)
    {
        var costCategoryCodes = await GetCostCategoriesAsync(tenant);
        return costCategoryCodes.Select(x => x.Code).ToArray();
    }
}