using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Domain.Contracts.Persistence.Common;

public interface IServerStatusPersistence : IDataPersistence<ServerStatus>
{
    Task<ServerStatus> GetServerStatusAsync(ServerStatus status);
    Task<ServerStatus[]> GetServerStatusesAsync(string tenant);
    Task<RepositoryActionResult<ServerStatus>> IncrementBatchAsync(ServerStatus serverStatus);
    Task<string[]> GetServerStatusCopYearsAsync(string region);
}