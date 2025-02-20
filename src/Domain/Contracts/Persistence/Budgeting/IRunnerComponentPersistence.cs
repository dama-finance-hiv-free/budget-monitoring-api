using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IRunnerComponentPersistence : IDataPersistence<RunnerComponent>
{
    Task<RunnerComponent[]> GetRunnerComponentsAsync(string tenant);
    /*RepositoryActionResult<RunnerComponent> SaveRunnerComponentAsync(RunnerComponent runnerComponent);
    RepositoryActionResult<RunnerComponent> DeleteRunnerComponentAsync(string runnerComponent);
    Task<RepositoryActionResult<RunnerComponent>> OpenSessionAsync(RunnerComponent runnerComponent, string status);*/
}
