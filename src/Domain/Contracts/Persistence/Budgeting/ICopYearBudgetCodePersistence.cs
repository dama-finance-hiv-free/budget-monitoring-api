using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ICopYearBudgetCodePersistence : IDataPersistence<CopYearBudgetCode>
{
    Task<CopYearBudgetCode[]> GetCopYearBudgetCodesAsync(string tenant);
    /*RepositoryActionResult<CopYearBudgetCode> SaveCopYearBudgetCodeAsync(CopYearBudgetCode copYearBudgetCode);
    RepositoryActionResult<CopYearBudgetCode> DeleteCopYearBudgetCodeAsync(string copYearBudgetCode);
    Task<RepositoryActionResult<CopYearBudgetCode>> OpenSessionAsync(CopYearBudgetCode copYearBudgetCode, string status);*/
}
