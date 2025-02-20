using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class ServerStatusPersistence : RepositoryBase<ServerStatus>, IServerStatusPersistence
{
    public ServerStatusPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<string[]> GetServerStatusCopYearsAsync(string region) =>
        await DbSet.Where(x => x.Region == region).Select(x => x.CopYear).ToArrayAsync();

    public async Task<RepositoryActionResult<ServerStatus>> IncrementBatchAsync(ServerStatus serverStatus) =>
        await EditAsync(serverStatus);

    public async Task<ServerStatus[]> GetServerStatusesAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    public async Task<ServerStatus> GetServerStatusAsync(ServerStatus status) => await ItemToGetAsync(status);

}