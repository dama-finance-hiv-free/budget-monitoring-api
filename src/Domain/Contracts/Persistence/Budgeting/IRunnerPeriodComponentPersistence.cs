using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IRunnerPeriodComponentPersistence : IDataPersistence<RunnerPeriodComponent>
{
    Task<RunnerPeriodComponent[]> GetRunnerPeriodComponentsAsync(string tenant);
    /*RepositoryActionResult<RunnerPeriodComponent> SaveRunnerPeriodComponentAsync(RunnerPeriodComponent runnerPeriodComponent);
    RepositoryActionResult<RunnerPeriodComponent> DeleteRunnerPeriodComponentAsync(string runnerPeriodComponent);
    Task<RepositoryActionResult<RunnerPeriodComponent>> OpenSessionAsync(RunnerPeriodComponent runnerPeriodComponent, string status);*/
}
