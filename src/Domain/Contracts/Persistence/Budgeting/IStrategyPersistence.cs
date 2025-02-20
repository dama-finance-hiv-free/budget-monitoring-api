using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface IStrategyPersistence : IDataPersistence<Strategy>
{
   Task<Strategy[]> GetStrategiesAsync(string tenant);
    /* RepositoryActionResult<Strategy> SaveStrategyAsync(Strategy strategy);
    RepositoryActionResult<Strategy> DeleteStrategyAsync(string strategy);
    Task<RepositoryActionResult<Strategy>> OpenSessionAsync(Strategy strategy, string status);*/
}
