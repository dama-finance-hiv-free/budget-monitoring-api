using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class TargetPersistence : RepositoryBase<Target>, ITargetPersistence
{
    public TargetPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<Target[]> GetTargetsAsync(string tenant, string region) =>
        await GetManyAsync(x => x.Tenant == tenant && x.Region == region);
}