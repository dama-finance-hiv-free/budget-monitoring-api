using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ICostCategoryPersistence : IDataPersistence<CostCategory>
{
   Task<CostCategory[]> GetCostCategoriesAsync(string tenant);
    /* RepositoryActionResult<CostCategory> SaveCostCategoryAsync(CostCategory costCategory);
    RepositoryActionResult<CostCategory> DeleteCostCategoryAsync(string costCategory);
    Task<RepositoryActionResult<CostCategory>> OpenSessionAsync(CostCategory costCategory, string status);*/
}
