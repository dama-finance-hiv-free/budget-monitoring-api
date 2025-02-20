using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ICopYearSitePersistence : IDataPersistence<CopYearSite>
{
   Task<CopYearSite[]> GetCopYearSitesAsync(string tenant);
   /* RepositoryActionResult<CopYearSite> SaveCopYearSiteAsync(CopYearSite copYearSite);
    RepositoryActionResult<CopYearSite> DeleteCopYearSiteAsync(string copYearSite);
    Task<RepositoryActionResult<CopYearSite>> OpenSessionAsync(CopYearSite copYearSite, string status);*/
}
