using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class BudgetHistoryPersistence : RepositoryBase<BudgetHistory>, IBudgetHistoryPersistence
{
    public BudgetHistoryPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<BudgetHistory>> AddAsync(BudgetHistory entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastBudgetHistory = DbSet.OrderByDescending(x => x.CopYear).ToArray().FirstOrDefault();
            var serial = lastBudgetHistory == null
                ? "1".ToTwoChar()
                : (lastBudgetHistory.CopYear.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.CopYear = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<BudgetHistory>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<BudgetHistory>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<BudgetHistory>(null, RepositoryActionStatus.Error, ex);
        }
    }

    protected override async Task<BudgetHistory> ItemToGetAsync(string tenant, string budgetHistory) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == budgetHistory);

    protected override async Task<BudgetHistory> ItemToGetAsync(BudgetHistory budgetHistory) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == budgetHistory.CopYear);
}