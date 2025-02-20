using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface IBudgetExecutionService : IServiceBase<BudgetExecutionVm>
{
    Task<BudgetExecutionVm[]> GetBudgetExecutionsAsync(BudgetAnalysisOptions options);
}