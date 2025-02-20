using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class CopYearCostCategoryPersistence : RepositoryBase<CopYearCostCategory>, ICopYearCostCategoryPersistence
{
    public CopYearCostCategoryPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<CopYearCostCategory>> AddAsync(CopYearCostCategory entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastCopYearCostCategory = DbSet.OrderByDescending(x => x.CopYear).ToArray().FirstOrDefault();
            var serial = lastCopYearCostCategory == null
                ? "1".ToTwoChar()
                : (lastCopYearCostCategory.CopYear.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.CopYear = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<CopYearCostCategory>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<CopYearCostCategory>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<CopYearCostCategory>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<CopYearCostCategory[]> GetCopYearCostCategoriesAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<CopYearCostCategory> ItemToGetAsync(string tenant, string copYearCostCategory) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == copYearCostCategory);

    protected override async Task<CopYearCostCategory> ItemToGetAsync(CopYearCostCategory copYearCostCategory) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == copYearCostCategory.CopYear);
}