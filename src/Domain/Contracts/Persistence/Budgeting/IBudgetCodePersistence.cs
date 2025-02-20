using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IBudgetCodePersistence : IDataPersistence<BudgetCode>
{
    Task<BudgetCode[]> GetBudgetCodesAsync(string tenant);
    /*RepositoryActionResult<BudgetCode> SaveBudgetCodeAsync(BudgetCode budgetcode);
    RepositoryActionResult<BudgetCode> DeleteBudgetCodeAsync(string budgetcode);
    Task<RepositoryActionResult<BudgetCode>> OpenSessionAsync(BudgetCode budgetcode, string status);*/
 
}
