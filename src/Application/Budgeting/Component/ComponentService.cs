using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Component;

public class ComponentService : ServiceBase<Domain.Entity.Budgeting.Component, ComponentVm>, IComponentService
{
    private readonly IComponentPersistence _componentPersistence;

    public ComponentService(IDataPersistence<Domain.Entity.Budgeting.Component> persistence, IMapper mapper, IDistributedCache cache, IComponentPersistence componentPersistence) : base(persistence, mapper, cache)
    {
        _componentPersistence = componentPersistence;
    }

    public async Task<ComponentVm[]> GetComponentsAsync(string tenant)
        => await GetCachedItemsAsync(() => _componentPersistence.GetComponentsAsync(tenant));

    public async Task<string[]> GetComponentCodesAsync(string tenant)
    {
        var components = await GetComponentsAsync(tenant);
        return components.Select(x => x.Code).ToArray();
    }
}