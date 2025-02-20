using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface ICostCategoryService : IServiceBase<CostCategoryVm>
{
    Task<CostCategoryVm[]> GetCostCategoriesAsync(string tenant);
    Task<string[]> GetCostCategoryCodesAsync(string tenant);
}