using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class CostCategoryPersistence : RepositoryBase<CostCategory>, ICostCategoryPersistence
{
    public CostCategoryPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<CostCategory>> AddAsync(CostCategory entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastCostCategory = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastCostCategory == null
                ? "1".ToTwoChar()
                : (lastCostCategory.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<CostCategory>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<CostCategory>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<CostCategory>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<CostCategory[]> GetCostCategoriesAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<CostCategory> ItemToGetAsync(string tenant, string costCategory) =>
        await GetFirstOrDefaultAsync(x => x.Code == costCategory);

    protected override async Task<CostCategory> ItemToGetAsync(CostCategory costCategory) =>
        await GetFirstOrDefaultAsync(x => x.Code == costCategory.Code);
}