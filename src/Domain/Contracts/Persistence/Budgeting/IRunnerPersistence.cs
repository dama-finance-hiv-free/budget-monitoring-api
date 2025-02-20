using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IRunnerPersistence : IDataPersistence<Runner>
{
   Task<Runner[]> GetRunnersAsync(string tenant);
   Task<RepositoryActionResult<Runner>> ArchiveAsync(Runner entity);
   Task<Runner[]> GetAllRunnersByRegionAsync(string region);
   Task<Runner[]> GetAllRunnersByBranchAsync(string tenant, string branch);
   Task<RepositoryActionResult<Runner>> AddAsync(string tenant, string code, string region, string project);
   Task<Runner> GetRunnerOrHistoryAsync(string tenant, string code);
   Task<Runner> GetActiveRunnerAsync(string region, string project);
}
