using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IBudgetPersistence : IDataPersistence<Budget>
{
    Task<Budget[]> GetBudgetsAsync(string tenant);
    Task<BudgetSummaryBatchVm> GetBudgetSummaryBatchAsync(string project, string component);
    Task<BudgetDashboardVm> GetBudgetDashboardAsync(string project, string component, string region, string period);
}
