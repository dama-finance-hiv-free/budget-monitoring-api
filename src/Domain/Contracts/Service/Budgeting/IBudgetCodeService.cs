using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IBudgetCodeService : IServiceBase<BudgetCodeVm>
{
    Task<BudgetCodeVm[]> GetBudgetCodesAsync(string tenant);
    Task<string[]> GetBudgetCodeCodesAsync(string tenant);
}