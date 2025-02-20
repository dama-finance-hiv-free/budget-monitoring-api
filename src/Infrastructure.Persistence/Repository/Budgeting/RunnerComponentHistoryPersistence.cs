using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RunnerComponentHistoryPersistence : RepositoryBase<RunnerComponentHistory>, IRunnerComponentHistoryPersistence
{
    public RunnerComponentHistoryPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<RunnerComponentHistory[]> GetRunnerComponentHistoriesAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<RunnerComponentHistory> ItemToGetAsync(string tenant, string runnerComponentHistory) =>
        await GetFirstOrDefaultAsync(x => x.Runner == runnerComponentHistory);

    protected override async Task<RunnerComponentHistory> ItemToGetAsync(RunnerComponentHistory runnerComponentHistory) =>
        await GetFirstOrDefaultAsync(x => x.Runner == runnerComponentHistory.Runner);
}