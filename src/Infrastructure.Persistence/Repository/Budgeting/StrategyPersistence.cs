using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class StrategyPersistence : RepositoryBase<Strategy>, IStrategyPersistence
{
    public StrategyPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Strategy>> AddAsync(Strategy entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastStrategy = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastStrategy == null
                ? "1".ToTwoChar()
                : (lastStrategy.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Strategy>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Strategy>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Strategy>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<Strategy[]> GetStrategiesAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<Strategy> ItemToGetAsync(string tenant, string strategy) =>
        await GetFirstOrDefaultAsync(x => x.Code == strategy);

    protected override async Task<Strategy> ItemToGetAsync(Strategy strategy) =>
        await GetFirstOrDefaultAsync(x => x.Code == strategy.Code);
}