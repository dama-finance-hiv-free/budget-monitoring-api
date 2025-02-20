using System.Linq;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class SitePersistence : RepositoryBase<Site>, ISitePersistence
{
    public SitePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<Site[]> GetSitesAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    public async Task<Site[]> GetSitesAsync(string tenant, string region)
    {
        var districts = await Context.DistrictSet.Where(x => x.Region == region).Select(x => x.Code).ToArrayAsync();
        return await GetManyAsync(x => x.Tenant == tenant && districts.Contains(x.District));
    }

    protected override async Task<Site> ItemToGetAsync(string tenant, string site) =>
        await GetFirstOrDefaultAsync(x => x.Code == site);

    protected override async Task<Site> ItemToGetAsync(Site site) =>
        await GetFirstOrDefaultAsync(x => x.Code == site.Code);
}