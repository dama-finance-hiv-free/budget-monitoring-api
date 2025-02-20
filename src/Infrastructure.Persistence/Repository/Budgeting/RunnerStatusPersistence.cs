using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RunnerStatusPersistence : RepositoryBase<RunnerStatus>, IRunnerStatusPersistence
{
    public RunnerStatusPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<RunnerStatus>> AddAsync(RunnerStatus entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastRunnerStatus = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastRunnerStatus == null
                ? "1".ToTwoChar()
                : (lastRunnerStatus.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<RunnerStatus>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<RunnerStatus>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<RunnerStatus>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<RunnerStatus[]> GetRunnersStatusAsync(string tenant) => await GetAllAsync();

    protected override async Task<RunnerStatus> ItemToGetAsync(string tenant, string runnerStatus) =>
        await GetFirstOrDefaultAsync(x => x.Code == runnerStatus);

    protected override async Task<RunnerStatus> ItemToGetAsync(RunnerStatus runnerStatus) =>
        await GetFirstOrDefaultAsync(x => x.Code == runnerStatus.Code);
}