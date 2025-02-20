using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IRunnerStatusPersistence : IDataPersistence<RunnerStatus>
{
   Task<RunnerStatus[]> GetRunnersStatusAsync(string tenant);
    /* RepositoryActionResult<RunnerStatus> SaveRunnerStatusAsync(RunnerStatus runnerStatus);
    RepositoryActionResult<RunnerStatus> DeleteRunnerStatusAsync(string runnerStatus);
    Task<RepositoryActionResult<RunnerStatus>> OpenSessionAsync(RunnerStatus runnerStatus, string status);*/
}
