using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class CopYearInterventionPersistence : RepositoryBase<CopYearIntervention>, ICopYearInterventionPersistence
{
    public CopYearInterventionPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<CopYearIntervention>> AddAsync(CopYearIntervention entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastCopYearIntervention = DbSet.OrderByDescending(x => x.CopYear).ToArray().FirstOrDefault();
            var serial = lastCopYearIntervention == null
                ? "1".ToTwoChar()
                : (lastCopYearIntervention.CopYear.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.CopYear = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<CopYearIntervention>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<CopYearIntervention>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<CopYearIntervention>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<CopYearIntervention[]> GetCopYearInterventionsAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<CopYearIntervention> ItemToGetAsync(string tenant, string copYearIntervention) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == copYearIntervention);

    protected override async Task<CopYearIntervention> ItemToGetAsync(CopYearIntervention copYearIntervention) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == copYearIntervention.CopYear);
}