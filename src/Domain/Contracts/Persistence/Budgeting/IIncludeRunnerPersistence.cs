using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IIncludeRunnerPersistence : IDataPersistence<IncludeRunner>
{
    Task<IncludeRunner[]> GetIncludeRunnersAsync(string tenant);
    /*RepositoryActionResult<IncludeRunner> SaveIncludeRunnerAsync(IncludeRunner budget);
    RepositoryActionResult<IncludeRunner> DeleteIncludeRunnerAsync(string budget);
    Task<RepositoryActionResult<IncludeRunner>> OpenSessionAsync(IncludeRunner budget, string status);*/
}
