using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Intervention;

public class InterventionService : ServiceBase<Domain.Entity.Budgeting.Intervention, InterventionVm>, IInterventionService
{
    private readonly IInterventionPersistence _interventionPersistence;

    public InterventionService(IDataPersistence<Domain.Entity.Budgeting.Intervention> persistence, IMapper mapper,
        IDistributedCache cache, IInterventionPersistence interventionPersistence) : base(persistence, mapper, cache)
    {
        _interventionPersistence = interventionPersistence;
    }

    public async Task<InterventionVm[]> GetInterventionsAsync(string tenant)
        => await GetCachedItemsAsync(() => _interventionPersistence.GetInterventionsAsync(tenant));
   

    public async Task<string[]> GetInterventionCodesAsync(string tenant)
    {
        var interventionCodes = await GetInterventionsAsync(tenant);
        return interventionCodes.Select(x => x.Code).ToArray();
    }
}