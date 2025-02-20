using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.AnnualTarget;

public class AnnualTargetService : ServiceBase<Domain.Entity.Budgeting.AnnualTarget, AnnualTargetVm>, IAnnualTargetService
{
    private readonly IAnnualTargetPersistence _annualTargetPersistence;
    private readonly IMapper _mapper;

    public AnnualTargetService(IDataPersistence<Domain.Entity.Budgeting.AnnualTarget> persistence, IMapper mapper,
        IDistributedCache cache, IAnnualTargetPersistence annualTargetPersistence) : base(persistence, mapper, cache)
    {
        _annualTargetPersistence = annualTargetPersistence;
        _mapper = mapper;
    }

    public async Task<AnnualTargetVm[]> GetAnnualTargetsAsync(string tenant)
    {
        var annualTargets = await _annualTargetPersistence.GetAnnualTargetsAsync(tenant);
        return  _mapper.Map<AnnualTargetVm[]>(annualTargets);
    }
}