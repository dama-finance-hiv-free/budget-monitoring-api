using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IRunnerHistoryPersistence : IDataPersistence<RunnerHistory>
{
   Task<RunnerHistory[]> GetRunnerHistoriesAsync(string tenant);
    /*  RepositoryActionResult<RunnerHistory> SaveRunnerHistoryAsync(RunnerHistory runnerHistory);
     RepositoryActionResult<RunnerHistory> DeleteRunnerHistoryAsync(string runnerHistory);
     Task<RepositoryActionResult<RunnerHistory>> OpenSessionAsync(RunnerHistory runnerHistory, string status);*/
}
