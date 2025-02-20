using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ICopYearCostCategoryPersistence : IDataPersistence<CopYearCostCategory>
{
    Task<CopYearCostCategory[]> GetCopYearCostCategoriesAsync(string tenant);
    /*RepositoryActionResult<CopYearCostCategory> SaveCopYearCostCategoryAsync(CopYearCostCategory copYearCostCategory);
    RepositoryActionResult<CopYearCostCategory> DeleteCopYearCostCategoryAsync(string copYearCostCategory);
    Task<RepositoryActionResult<CopYearCostCategory>> OpenSessionAsync(CopYearCostCategory copYearCostCategory, string status);*/
}
