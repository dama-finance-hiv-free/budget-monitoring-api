using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RunnerPeriodComponentHistoryPersistence : RepositoryBase<RunnerPeriodComponentHistory>, IRunnerPeriodComponentHistoryPersistence
{
    public RunnerPeriodComponentHistoryPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<RunnerPeriodComponentHistory>> AddAsync(RunnerPeriodComponentHistory entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastRunnerPeriodComponentHistory = DbSet.OrderByDescending(x => x.Project).ToArray().FirstOrDefault();
            var serial = lastRunnerPeriodComponentHistory == null
                ? "1".ToTwoChar()
                : (lastRunnerPeriodComponentHistory.Project.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Project = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<RunnerPeriodComponentHistory>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<RunnerPeriodComponentHistory>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<RunnerPeriodComponentHistory>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<RunnerPeriodComponentHistory[]> GetRunnerPeriodComponentHistoriesAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<RunnerPeriodComponentHistory> ItemToGetAsync(string tenant, string runnerComponentHistory) =>
        await GetFirstOrDefaultAsync(x => x.Project == runnerComponentHistory);

    protected override async Task<RunnerPeriodComponentHistory> ItemToGetAsync(RunnerPeriodComponentHistory runnerComponentHistory) =>
        await GetFirstOrDefaultAsync(x => x.Project == runnerComponentHistory.Project);
}