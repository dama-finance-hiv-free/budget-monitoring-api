using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IRunnerComponentHistoryPersistence : IDataPersistence<RunnerComponentHistory>
{
    Task<RunnerComponentHistory[]> GetRunnerComponentHistoriesAsync(string tenant);
    /* RepositoryActionResult<RunnerComponentHistory> SaveRunnerComponentHistoryAsync(RunnerComponentHistory runnerComponentHistory);
    RepositoryActionResult<RunnerComponentHistory> DeleteRunnerComponentHistoryAsync(string runnerComponentHistory);
    Task<RepositoryActionResult<RunnerComponentHistory>> OpenSessionAsync(RunnerComponentHistory runnerComponentHistory, string status);*/
}
