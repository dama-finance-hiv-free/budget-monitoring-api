using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Common.MonthName;

public class MonthNameService : ServiceBase<Domain.Entity.Common.MonthName, MonthNameVm>, IMonthNameService
{
    private readonly IMonthNamePersistence _monthNamePersistence;
    private readonly IMapper _mapper;

    public MonthNameService(IDataPersistence<Domain.Entity.Common.MonthName> persistence, IMapper mapper,
        IDistributedCache cache, IMonthNamePersistence monthNamePersistence) : base(persistence, mapper, cache)
    {
        _monthNamePersistence = monthNamePersistence;
        _mapper = mapper;
    }

    public async Task<MonthNameVm[]> GetMonthNamesAsync(string lid)
    {
        var monthNames = await _monthNamePersistence.GetMonthNames("01");
        return _mapper.Map<MonthNameVm[]>(monthNames);
    }
}