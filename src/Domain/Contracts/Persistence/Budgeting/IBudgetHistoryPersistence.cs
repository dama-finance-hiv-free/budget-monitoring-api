using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IBudgetHistoryPersistence : IDataPersistence<BudgetHistory>
{
   /* Task<BudgetHistory[]> GetBudgetHistoriesAsync(string tenant, string user);
    RepositoryActionResult<BudgetHistory> SaveBudgetHistoryAsync(BudgetHistory budgetHistory);
    RepositoryActionResult<BudgetHistory> DeleteBudgetHistoryAsync(string budgetHistory);
    Task<RepositoryActionResult<BudgetHistory>> OpenSessionAsync(BudgetHistory budgetHistory, string status);
    Task<DateTime> GetLastBudgetHistoryAsync(string budgetHistory, DateTime transDate);*/
}
