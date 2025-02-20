using System.Linq;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class SurgeActivityPersistence : RepositoryBase<SurgeActivity>, ISurgeActivityPersistence
{
    public SurgeActivityPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<string[]> GetSurgeActivityCodesAsync()
    {
        return await DbSet.Select(x => x.Code)
            .ToArrayAsync();
    }
}