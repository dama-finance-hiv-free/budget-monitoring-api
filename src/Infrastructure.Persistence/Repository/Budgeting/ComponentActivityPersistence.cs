using System.Linq;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class ComponentActivityPersistence : RepositoryBase<ComponentActivity>, IComponentActivityPersistence
{
    public ComponentActivityPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<string[]> GetComponentActivityCodesAsync(string tenant, string copYear, string component)
    {
        return await DbSet.Where(x => x.Component == component && x.CopYear == copYear)
            .Select(x => x.Activity)
            .ToArrayAsync();
    }
}