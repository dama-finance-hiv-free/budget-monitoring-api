using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class BudgetCodePersistence : RepositoryBase<BudgetCode>, IBudgetCodePersistence
{
    public BudgetCodePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<BudgetCode>> AddAsync(BudgetCode entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastBudgetCode = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastBudgetCode == null
                ? "1".ToTwoChar()
                : (lastBudgetCode.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<BudgetCode>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<BudgetCode>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<BudgetCode>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<BudgetCode[]> GetBudgetCodesAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<BudgetCode> ItemToGetAsync(BudgetCode budgetCode) =>
        await GetFirstOrDefaultAsync(x => x.Code == budgetCode.Code);
}