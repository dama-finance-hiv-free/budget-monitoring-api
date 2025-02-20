using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.CopYearCostCategory;

public class CopYearCostCategoryService :
    ServiceBase<Domain.Entity.Budgeting.CopYearCostCategory, CopYearCostCategoryVm>, ICopYearCostCategoryService
{
    private readonly ICopYearCostCategoryPersistence _copYearCostCategoryPersistence;
    private readonly IMapper _mapper;

    public CopYearCostCategoryService(IDataPersistence<Domain.Entity.Budgeting.CopYearCostCategory> persistence,
        IMapper mapper, IDistributedCache cache, ICopYearCostCategoryPersistence copYearCostCategoryPersistence) : base(
        persistence, mapper, cache)
    {
        _copYearCostCategoryPersistence = copYearCostCategoryPersistence;
        _mapper = mapper;
    }

    public async Task<CopYearCostCategoryVm[]> GetCopYearCostCategoriesAsync(string tenant)
    {
        var copYearCostCategories = await _copYearCostCategoryPersistence.GetCopYearCostCategoriesAsync(tenant);
        return  _mapper.Map<CopYearCostCategoryVm[]>(copYearCostCategories);
    }
}