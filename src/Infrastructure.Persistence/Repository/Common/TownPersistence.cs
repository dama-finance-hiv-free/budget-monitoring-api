using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class TownPersistence : RepositoryBase<Town>, ITownPersistence
{
    public TownPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Town>> AddAsync(Town entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastTown = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastTown == null
                ? "1".ToTwoChar()
                : (lastTown.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Town>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Town>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Town>(null, RepositoryActionStatus.Error, ex);
        }
    }

    protected override async Task<Town> ItemToGetAsync(string tenant, string town) =>
        await GetFirstOrDefaultAsync(x => x.Code == town);

    protected override async Task<Town> ItemToGetAsync(Town town) =>
        await GetFirstOrDefaultAsync(x => x.Code == town.Code);
}
