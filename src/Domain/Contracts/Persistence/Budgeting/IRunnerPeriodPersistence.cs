using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IRunnerPeriodPersistence : IDataPersistence<RunnerPeriod>
{
    Task<RunnerPeriod[]> GetRunnerPeriodsAsync(string tenant);
    /*RepositoryActionResult<RunnerPeriod> SaveRunnerPeriodAsync(RunnerPeriod runnerPeriod);
    RepositoryActionResult<RunnerPeriod> DeleteRunnerPeriodAsync(string runnerPeriod);
    Task<RepositoryActionResult<RunnerPeriod>> OpenSessionAsync(RunnerPeriod runnerPeriod, string status);*/
    Task<RepositoryActionResult<RunnerPeriod>> ActivateAsync(RunnerPeriod runnerPeriod);
    Task<RepositoryActionResult<RunnerPeriod>> ArchiveAsync(RunnerPeriod runnerPeriod);
    Task<string[]> GetRunnerPeriodHistoryCodesAsync(string tenant, string region, string copYear, string project);
}
