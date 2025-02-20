using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RunnerPeriodComponentPersistence : RepositoryBase<RunnerPeriodComponent>, IRunnerPeriodComponentPersistence
{
    public RunnerPeriodComponentPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<RunnerPeriodComponent[]> GetRunnerPeriodComponentsAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<RunnerPeriodComponent> ItemToGetAsync(string tenant, string runnerPeriodComponent) =>
        await GetFirstOrDefaultAsync(x => x.Tenant == tenant && x.RunnerPeriod == runnerPeriodComponent);

    protected override async Task<RunnerPeriodComponent> ItemToGetAsync(RunnerPeriodComponent runnerPeriodComponent) =>
        await GetFirstOrDefaultAsync(x =>
            x.Tenant == runnerPeriodComponent.Tenant && x.RunnerPeriod == runnerPeriodComponent.RunnerPeriod);
}