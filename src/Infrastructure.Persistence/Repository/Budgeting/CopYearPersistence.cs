using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class CopYearPersistence : RepositoryBase<CopYear>, ICopYearPersistence
{
    public CopYearPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<CopYear>> AddAsync(CopYear entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastCopYear = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastCopYear == null
                ? "1".ToTwoChar()
                : (lastCopYear.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<CopYear>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<CopYear>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<CopYear>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<CopYear[]> GetCopYearsAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<CopYear> ItemToGetAsync(string tenant, string copYear) =>
        await GetFirstOrDefaultAsync(x => x.Code == copYear);

    protected override async Task<CopYear> ItemToGetAsync(CopYear copYear) =>
        await GetFirstOrDefaultAsync(x => x.Code == copYear.Code);
}