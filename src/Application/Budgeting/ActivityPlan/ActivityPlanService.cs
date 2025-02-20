using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.ActivityPlan;

public class ActivityPlanService : ServiceBase<Domain.Entity.Budgeting.ActivityPlan, ActivityPlanVm>, IActivityPlanService
{
    private readonly IActivityPlanPersistence _activityPlanPersistence;
    private readonly IMapper _mapper;

    public ActivityPlanService(IDataPersistence<Domain.Entity.Budgeting.ActivityPlan> persistence, IMapper mapper,
        IDistributedCache cache, IActivityPlanPersistence activityPlanPersistence) : base(persistence, mapper, cache)
    {
        _activityPlanPersistence = activityPlanPersistence;
        _mapper = mapper;
    }

    public async Task<ActivityPlanVm[]> GetActivityPlansAsync(string tenant)
    {
        var activityPlans = await _activityPlanPersistence.GetActivityPlansAsync(tenant);
        return _mapper.Map<ActivityPlanVm[]>(activityPlans);
    }

    public async Task<ActivityPlanVm[]> GetActivityPlansAsync(string tenant, string copYear, string component, string project)
    {
        var activityPlans = await _activityPlanPersistence.GetActivityPlansAsync(tenant, copYear, component, project);
        return _mapper.Map<ActivityPlanVm[]>(activityPlans);
    }

    public async Task<ActivityPlanVm[]> GetSurgeActivityPlansAsync(string tenant, string copYear, string component, string project)
    {
        var activityPlans = await _activityPlanPersistence.GetSurgeActivityPlansAsync(tenant, copYear, component, project);
        return _mapper.Map<ActivityPlanVm[]>(activityPlans);
    }

    public async Task<string[]> GetActivityPlanCodesAsync(string tenant)
    {
        var activityPlans = await GetActivityPlansAsync(tenant);
        return activityPlans.Select(x => x.Code).ToArray();
    }

    public async Task<ActivityPlanVm> GetActivityPlanAsync(string tenant, string code)
    {
        var entity = await _activityPlanPersistence.GetAsync(tenant, code);
        return _mapper.Map<ActivityPlanVm>(entity);
    }
}