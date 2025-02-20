using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IBudgetService : IServiceBase<BudgetVm>
{
    Task<BudgetVm[]> GetBudgetsAsync(string tenant);
}