using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RegionPersistence : RepositoryBase<Region>, IRegionPersistence
{
    public RegionPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Region>> AddAsync(Region entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastRegion = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastRegion == null
                ? "1".ToTwoChar()
                : (lastRegion.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Region>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Region>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Region>(null, RepositoryActionStatus.Error, ex);
        }
    }

    protected override async Task<Region> ItemToGetAsync(string tenant, string quarter) =>
        await GetFirstOrDefaultAsync(x => x.Code == quarter);

    protected override async Task<Region> ItemToGetAsync(Region quarter) =>
        await GetFirstOrDefaultAsync(x => x.Code == quarter.Code);
}