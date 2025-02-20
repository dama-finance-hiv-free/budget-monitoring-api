using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.SurgeActivity;

public class SurgeActivityService : ServiceBase<Domain.Entity.Budgeting.SurgeActivity, SurgeActivityVm>, ISurgeActivityService
{
    private readonly ISurgeActivityPersistence _surgeActivityPersistence;
    private readonly IMapper _mapper;

    public SurgeActivityService(IDataPersistence<Domain.Entity.Budgeting.SurgeActivity> persistence, IMapper mapper,
        IDistributedCache cache, ISurgeActivityPersistence surgeActivityPersistence) : base(persistence, mapper, cache)
    {
        _surgeActivityPersistence = surgeActivityPersistence;
        _mapper = mapper;
    }

    public async Task<SurgeActivityVm[]> GetSurgeActivitiesAsync()
    {
        var surgeActivities = await _surgeActivityPersistence.GetAllAsync();
        return _mapper.Map<SurgeActivityVm[]>(surgeActivities);
    }
}