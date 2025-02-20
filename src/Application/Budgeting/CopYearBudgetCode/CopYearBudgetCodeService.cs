using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.CopYearBudgetCode;

public class CopYearBudgetCodeService : ServiceBase<Domain.Entity.Budgeting.CopYearBudgetCode, CopYearBudgetCodeVm>, ICopYearBudgetCodeService
{
    private readonly ICopYearBudgetCodePersistence _cupYearBudgetCodePersistence;
    private readonly IMapper _mapper;

    public CopYearBudgetCodeService(IDataPersistence<Domain.Entity.Budgeting.CopYearBudgetCode> persistence,
        IMapper mapper, IDistributedCache cache, ICopYearBudgetCodePersistence cupYearBudgetCodePersistence) : base(
        persistence, mapper, cache)
    {
        _cupYearBudgetCodePersistence = cupYearBudgetCodePersistence;
        _mapper = mapper;
    }

    public async Task<CopYearBudgetCodeVm[]> GetCopYearBudgetCodesAsync(string tenant)
    {
        var cupYearBudgetCodes = await _cupYearBudgetCodePersistence.GetCopYearBudgetCodesAsync(tenant);
        return  _mapper.Map<CopYearBudgetCodeVm[]>(cupYearBudgetCodes);
    }
}