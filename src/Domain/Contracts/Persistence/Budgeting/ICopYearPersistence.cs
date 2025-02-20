using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ICopYearPersistence : IDataPersistence<CopYear>
{
   Task<CopYear[]> GetCopYearsAsync(string tenant);
   /* RepositoryActionResult<CopYear> SaveCopYearAsync(CopYear copYear);
    RepositoryActionResult<CopYear> DeleteCopYearAsync(string copYear);
    Task<RepositoryActionResult<CopYear>> OpenSessionAsync(CopYear copYear, string status);*/
}
