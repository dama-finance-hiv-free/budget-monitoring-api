using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ITargetHistoryPersistence : IDataPersistence<TargetHistory>
{
   Task<TargetHistory[]> GetTargetHistoriesAsync(string tenant);
    /* RepositoryActionResult<TargetHistory> SaveTargetHistoryAsync(TargetHistory targetHistory);
    RepositoryActionResult<TargetHistory> DeleteTargetHistoryAsync(string targetHistory);
    Task<RepositoryActionResult<TargetHistory>> OpenSessionAsync(TargetHistory targetHistory, string status);*/
}
