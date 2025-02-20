using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class CopYearOutlayPersistence : RepositoryBase<CopYearOutlay>, ICopYearOutlayPersistence
{
    public CopYearOutlayPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<CopYearOutlay>> AddAsync(CopYearOutlay entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastCopYearOutlay = DbSet.OrderByDescending(x => x.CopYear).ToArray().FirstOrDefault();
            var serial = lastCopYearOutlay == null
                ? "1".ToTwoChar()
                : (lastCopYearOutlay.CopYear.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.CopYear = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<CopYearOutlay>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<CopYearOutlay>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<CopYearOutlay>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<CopYearOutlay[]> GetCopYearOutlaysAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<CopYearOutlay> ItemToGetAsync(string tenant, string copYearOutlay) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == copYearOutlay);

    protected override async Task<CopYearOutlay> ItemToGetAsync(CopYearOutlay copYearOutlay) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == copYearOutlay.CopYear);
}