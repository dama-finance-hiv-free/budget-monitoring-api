using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.CopYearIntervention;

public class CopYearInterventionService :
    ServiceBase<Domain.Entity.Budgeting.CopYearIntervention, CopYearInterventionVm>, ICopYearInterventionService
{
    private readonly ICopYearInterventionPersistence _copYearInterventionPersistence;
    private readonly IMapper _mapper;

    public CopYearInterventionService(IDataPersistence<Domain.Entity.Budgeting.CopYearIntervention> persistence,
        IMapper mapper, IDistributedCache cache, ICopYearInterventionPersistence copYearInterventionPersistence) : base(
        persistence, mapper, cache)
    {
        _copYearInterventionPersistence = copYearInterventionPersistence;
        _mapper = mapper;
    }

    public async Task<CopYearInterventionVm[]> GetCopYearInterventionsAsync(string tenant)
    {
        var copYearInterventions = await _copYearInterventionPersistence.GetCopYearInterventionsAsync(tenant);
        return  _mapper.Map<CopYearInterventionVm[]>(copYearInterventions);
    }
}