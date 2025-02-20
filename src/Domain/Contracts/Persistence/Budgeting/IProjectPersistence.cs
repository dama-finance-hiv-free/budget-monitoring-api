using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IProjectPersistence : IDataPersistence<Project>
{
    Task<Project[]> GetProjectsAsync(string tenant);
    /* RepositoryActionResult<Project> SaveProjectAsync(Project project);
     RepositoryActionResult<Project> DeleteProjectAsync(string project);
     Task<RepositoryActionResult<Project>> OpenSessionAsync(Project project, string status);*/
}
