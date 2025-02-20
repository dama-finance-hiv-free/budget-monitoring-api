using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class SystemMenuPersistence : RepositoryBase<SystemMenu>, ISystemMenuPersistence
{
    public SystemMenuPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<SystemMenu[]> GetSystemMenusAsync(string lid) => await GetManyAsync(x => x.Lid == lid);
}
