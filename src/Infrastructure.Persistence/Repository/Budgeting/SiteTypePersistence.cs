using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class SiteTypePersistence : RepositoryBase<SiteType>, ISiteTypePersistence
{
    public SiteTypePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<SiteType>> AddAsync(SiteType entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastSiteType = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastSiteType == null
                ? "1".ToTwoChar()
                : (lastSiteType.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<SiteType>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<SiteType>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<SiteType>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<SiteType[]> GetSiteTypesAsync(string tenant) => await GetAllAsync();

    protected override async Task<SiteType> ItemToGetAsync(string tenant, string siteType) =>
        await GetFirstOrDefaultAsync(x => x.Code == siteType);

    protected override async Task<SiteType> ItemToGetAsync(SiteType siteType) =>
        await GetFirstOrDefaultAsync(x => x.Code == siteType.Code);
}