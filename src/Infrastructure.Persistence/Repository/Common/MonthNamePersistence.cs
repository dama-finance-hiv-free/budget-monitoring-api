using System.Linq;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class MonthNamePersistence : RepositoryBase<MonthName>, IMonthNamePersistence
{
    public MonthNamePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<MonthName[]> GetMonthNames(string lang) => await DbSet.Where(x => x.Lid == lang).ToArrayAsync();

    protected override async Task<MonthName> ItemToGetAsync(string tenant, string monthName) =>
        await GetFirstOrDefaultAsync(x => x.Code == monthName);

    protected override async Task<MonthName> ItemToGetAsync(MonthName monthName) =>
        await GetFirstOrDefaultAsync(x => x.Code == monthName.Code);
}
