using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class AnnualTargetPersistence : RepositoryBase<AnnualTarget>, IAnnualTargetPersistence
{
    public AnnualTargetPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<AnnualTarget>> AddAsync(AnnualTarget entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastAnnualTarget = DbSet.OrderByDescending(x => x.CopYear).ToArray().FirstOrDefault();
            var serial = lastAnnualTarget == null
                ? "1".ToTwoChar()
                : (lastAnnualTarget.CopYear.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.CopYear = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<AnnualTarget>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<AnnualTarget>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<AnnualTarget>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<AnnualTarget[]> GetAnnualTargetsAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<AnnualTarget> ItemToGetAsync(string tenant, string annualTarget) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == annualTarget);

    protected override async Task<AnnualTarget> ItemToGetAsync(AnnualTarget annualTarget) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == annualTarget.CopYear);
}