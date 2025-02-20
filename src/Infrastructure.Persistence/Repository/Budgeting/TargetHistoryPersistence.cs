using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class TargetHistoryPersistence : RepositoryBase<TargetHistory>, ITargetHistoryPersistence
{
    public TargetHistoryPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<TargetHistory>> AddAsync(TargetHistory entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastTargetHistory = DbSet.OrderByDescending(x => x.CopYear).ToArray().FirstOrDefault();
            var serial = lastTargetHistory == null
                ? "1".ToTwoChar()
                : (lastTargetHistory.CopYear.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.CopYear = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<TargetHistory>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<TargetHistory>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<TargetHistory>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<TargetHistory[]> GetTargetHistoriesAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<TargetHistory> ItemToGetAsync(string tenant, string target) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == target);

    protected override async Task<TargetHistory> ItemToGetAsync(TargetHistory target) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == target.CopYear);
}