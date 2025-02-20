using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class ZonePersistence : RepositoryBase<Zone>, IZonePersistence
{
    public ZonePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Zone>> AddAsync(Zone entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastZone = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastZone == null
                ? "1".ToTwoChar()
                : (lastZone.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Zone>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Zone>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Zone>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<Zone[]> GetZonesAsync(string tenant) => await GetAllAsync();

    protected override async Task<Zone> ItemToGetAsync(string tenant, string zone) =>
        await GetFirstOrDefaultAsync(x => x.Code == zone);

    protected override async Task<Zone> ItemToGetAsync(Zone zone) =>
        await GetFirstOrDefaultAsync(x => x.Code == zone.Code);
}