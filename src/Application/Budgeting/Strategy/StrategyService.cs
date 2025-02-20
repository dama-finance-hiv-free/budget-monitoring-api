using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Strategy;

public class StrategyService : ServiceBase<Domain.Entity.Budgeting.Strategy, StrategyVm>, IStrategyService
{
    private readonly IStrategyPersistence _strategyPersistence;

    public StrategyService(IDataPersistence<Domain.Entity.Budgeting.Strategy> persistence, IMapper mapper, IDistributedCache cache, IStrategyPersistence strategyPersistence) : base(persistence, mapper, cache)
    {
        _strategyPersistence = strategyPersistence;
    }

    public async Task<StrategyVm[]> GetStrategiesAsync(string tenant)
        => await GetCachedItemsAsync(() => _strategyPersistence.GetStrategiesAsync(tenant));


    public async Task<string[]> GetStrategyCodesAsync(string tenant)
    {
        var strategies = await GetStrategiesAsync(tenant);
        return strategies.Select(x => x.Code).ToArray();
    }
}