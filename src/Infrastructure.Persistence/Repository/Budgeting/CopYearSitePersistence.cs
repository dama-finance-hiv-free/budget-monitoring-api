using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class CopYearSitePersistence : RepositoryBase<CopYearSite>, ICopYearSitePersistence
{
    public CopYearSitePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<CopYearSite>> AddAsync(CopYearSite entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastCopYearSite = DbSet.OrderByDescending(x => x.CopYear).ToArray().FirstOrDefault();
            var serial = lastCopYearSite == null
                ? "1".ToTwoChar()
                : (lastCopYearSite.CopYear.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.CopYear = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<CopYearSite>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<CopYearSite>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<CopYearSite>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<CopYearSite[]> GetCopYearSitesAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<CopYearSite> ItemToGetAsync(string tenant, string copYearSite) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == copYearSite);

    protected override async Task<CopYearSite> ItemToGetAsync(CopYearSite copYearSite) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == copYearSite.CopYear);
}