using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IRunnerPeriodHistoryPersistence : IDataPersistence<RunnerPeriodHistory>
{
   Task<RunnerPeriodHistory[]> GetRunnerPeriodHistoriesAsync(string tenant);
    /*  RepositoryActionResult<RunnerPeriodHistory> SaveRunnerPeriodHistoryAsync(RunnerPeriodHistory runnerPeriodHistory);
     RepositoryActionResult<RunnerPeriodHistory> DeleteRunnerPeriodHistoryAsync(string runnerPeriodHistory);
     Task<RepositoryActionResult<RunnerPeriodHistory>> OpenSessionAsync(RunnerPeriodHistory runnerPeriodHistory, string status);*/
}
