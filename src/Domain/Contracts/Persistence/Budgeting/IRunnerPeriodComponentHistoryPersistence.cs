using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IRunnerPeriodComponentHistoryPersistence : IDataPersistence<RunnerPeriodComponentHistory>
{
    Task<RunnerPeriodComponentHistory[]> GetRunnerPeriodComponentHistoriesAsync(string tenant);
    /*RepositoryActionResult<RunnerPeriodComponentHistory> SaveRunnerPeriodComponentHistoryAsync(RunnerPeriodComponentHistory runnerPeriodComponentHistory);
    RepositoryActionResult<RunnerPeriodComponentHistory> DeleteRunnerPeriodComponentHistoryAsync(string runnerPeriodComponentHistory);
    Task<RepositoryActionResult<RunnerPeriodComponentHistory>> OpenSessionAsync(RunnerPeriodComponentHistory runnerPeriodComponentHistory, string status);*/
}
