using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RunnerPeriodStatusPersistence : RepositoryBase<RunnerPeriodStatus>, IRunnerPeriodStatusPersistence
{
    public RunnerPeriodStatusPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<RunnerPeriodStatus>> AddAsync(RunnerPeriodStatus entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastRunnerPeriodStatus = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastRunnerPeriodStatus == null
                ? "1".ToTwoChar()
                : (lastRunnerPeriodStatus.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<RunnerPeriodStatus>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<RunnerPeriodStatus>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<RunnerPeriodStatus>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<RunnerPeriodStatus[]> GetRunnerPeriodsStatusAsync(string tenant) => await GetAllAsync();

    protected override async Task<RunnerPeriodStatus> ItemToGetAsync(string tenant, string runnerPeriodStatus) =>
        await GetFirstOrDefaultAsync(x => x.Code == runnerPeriodStatus);

    protected override async Task<RunnerPeriodStatus> ItemToGetAsync(RunnerPeriodStatus runnerPeriodStatus) =>
        await GetFirstOrDefaultAsync(x => x.Code == runnerPeriodStatus.Code);
}