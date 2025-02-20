using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class IncludeRunnerPersistence : RepositoryBase<IncludeRunner>, IIncludeRunnerPersistence
{
    public IncludeRunnerPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<IncludeRunner>> AddAsync(IncludeRunner entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastIncludeRunner = DbSet.OrderByDescending(x => x.User).ToArray().FirstOrDefault();
            var serial = lastIncludeRunner == null
                ? "1".ToTwoChar()
                : (lastIncludeRunner.User.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.User = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<IncludeRunner>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<IncludeRunner>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<IncludeRunner>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<IncludeRunner[]> GetIncludeRunnersAsync(string tenant) => await GetAllAsync();

    protected override async Task<IncludeRunner> ItemToGetAsync(string tenant, string includeRunner) =>
        await GetFirstOrDefaultAsync(x => x.User == includeRunner);

    protected override async Task<IncludeRunner> ItemToGetAsync(IncludeRunner includeRunner) =>
        await GetFirstOrDefaultAsync(x => x.User == includeRunner.User);
}