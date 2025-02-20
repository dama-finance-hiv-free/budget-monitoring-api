using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IProjectSitePersistence : IDataPersistence<ProjectSite>
{
    Task<ProjectSite[]> GetProjectSitesAsync(string tenant);
    /* RepositoryActionResult<ProjectSite> SaveProjectSiteAsync(ProjectSite projectSite);
     RepositoryActionResult<ProjectSite> DeleteProjectSiteAsync(string projectSite);
     Task<RepositoryActionResult<ProjectSite>> OpenSessionAsync(ProjectSite projectSite, string status);*/
}
