using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RunnerHistoryPersistence : RepositoryBase<RunnerHistory>, IRunnerHistoryPersistence
{
    public RunnerHistoryPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<RunnerHistory[]> GetRunnerHistoriesAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<RunnerHistory> ItemToGetAsync(string tenant, string runnerHistory) =>
        await GetFirstOrDefaultAsync(x => x.Code == runnerHistory);

    protected override async Task<RunnerHistory> ItemToGetAsync(RunnerHistory runnerHistory) =>
        await GetFirstOrDefaultAsync(x => x.Code == runnerHistory.Code);
}