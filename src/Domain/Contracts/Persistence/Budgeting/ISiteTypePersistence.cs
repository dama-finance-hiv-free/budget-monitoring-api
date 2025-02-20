using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ISiteTypePersistence : IDataPersistence<SiteType>
{
   Task<SiteType[]> GetSiteTypesAsync(string tenant);
    /*  RepositoryActionResult<SiteType> SaveSiteTypeAsync(SiteType siteType);
     RepositoryActionResult<SiteType> DeleteSiteTypeAsync(string siteType);
     Task<RepositoryActionResult<SiteType>> OpenSessionAsync(SiteType siteType, string status);*/
}
