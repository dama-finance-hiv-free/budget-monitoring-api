using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class CopYearBudgetCodePersistence : RepositoryBase<CopYearBudgetCode>, ICopYearBudgetCodePersistence
{
    public CopYearBudgetCodePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<CopYearBudgetCode>> AddAsync(CopYearBudgetCode entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastCopYearBudgetCode = DbSet.OrderByDescending(x => x.CopYear).ToArray().FirstOrDefault();
            var serial = lastCopYearBudgetCode == null
                ? "1".ToTwoChar()
                : (lastCopYearBudgetCode.CopYear.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.CopYear = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<CopYearBudgetCode>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<CopYearBudgetCode>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<CopYearBudgetCode>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<CopYearBudgetCode[]> GetCopYearBudgetCodesAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<CopYearBudgetCode> ItemToGetAsync(string tenant, string copYearBudgetCode) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == copYearBudgetCode);

    protected override async Task<CopYearBudgetCode> ItemToGetAsync(CopYearBudgetCode copYearBudgetCode) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == copYearBudgetCode.CopYear);
}