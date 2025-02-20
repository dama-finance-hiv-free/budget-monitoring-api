using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.CopYear;

public class CopYearService : ServiceBase<Domain.Entity.Budgeting.CopYear, CopYearVm>, ICopYearService
{
    private readonly ICopYearPersistence _copYearPersistence;

    public CopYearService(IDataPersistence<Domain.Entity.Budgeting.CopYear> persistence, IMapper mapper,
        IDistributedCache cache, ICopYearPersistence copYearPersistence) : base(persistence, mapper, cache)
    {
        _copYearPersistence = copYearPersistence;
    }

    public async Task<CopYearVm[]> GetCopYearsAsync(string tenant) =>
        await GetCachedItemsAsync(() => _copYearPersistence.GetCopYearsAsync(tenant));

    public async Task<CopYearVm> GetCopYearAsync(string tenant, string code) =>
        await GetAsync(tenant, code);

    public async Task<string[]> GetCopYearCodesAsync(string tenant)
    {
        var copYearCodes = await GetCopYearsAsync(tenant);
        return copYearCodes.Select(x => x.Code).ToArray();
    }
}