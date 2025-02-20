using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IRunnerPeriodStatusPersistence : IDataPersistence<RunnerPeriodStatus>
{
    Task<RunnerPeriodStatus[]> GetRunnerPeriodsStatusAsync(string tenant);
    /*RepositoryActionResult<RunnerPeriodStatus> SaveRunnerPeriodStatusAsync(RunnerPeriodStatus runnerPeriodStatus);
    RepositoryActionResult<RunnerPeriodStatus> DeleteRunnerPeriodStatusAsync(string runnerPeriodStatus);
    Task<RepositoryActionResult<RunnerPeriodStatus>> OpenSessionAsync(RunnerPeriodStatus runnerPeriodStatus, string status);*/
}
