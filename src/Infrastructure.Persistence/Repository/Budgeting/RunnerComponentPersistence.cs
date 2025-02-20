using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RunnerComponentPersistence : RepositoryBase<RunnerComponent>, IRunnerComponentPersistence
{
    public RunnerComponentPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<RunnerComponent[]> GetRunnerComponentsAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<RunnerComponent> ItemToGetAsync(string tenant, string runner) =>
        await GetFirstOrDefaultAsync(x => x.Runner == runner);

    protected override async Task<RunnerComponent> ItemToGetAsync(RunnerComponent runnerComponent) =>
        await GetFirstOrDefaultAsync(x => x.Runner == runnerComponent.Runner);
}