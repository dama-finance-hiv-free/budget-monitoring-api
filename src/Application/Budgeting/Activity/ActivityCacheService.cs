using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Dama.Fin.Application.Budgeting.Activity
{
    public interface IActivityCacheService
    {
        Task UpdateCacheAsync(string tenant, string region, string activityType, string branch, string project);
    }

    public class ActivityCacheService : IActivityCacheService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public ActivityCacheService(IServiceProvider serviceProvider, IMapper mapper, IDistributedCache cache)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task UpdateCacheAsync(string tenant, string region, string activityType, string branch, string project)
        {
            try
            {
                await using var scope = _serviceProvider.CreateAsyncScope();
                var activityPersistence = scope.ServiceProvider.GetRequiredService<IActivityPersistence>();

                var key = $"urn:{tenant}:{region}:{activityType}:{branch}:{typeof(ActivityVm)}";

                if (_cache == null)
                    return;

                var cachedData = await _cache.GetAsync(key);
                if (cachedData != null) await _cache.RemoveAsync(key);

                var entities = await activityPersistence.GetActivitiesAsync(tenant, region, activityType, branch);
                var models = _mapper.Map<ActivityVm[]>(entities);

                var cachedDataString = JsonSerializer.Serialize(models);
                var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(20))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(15));

                await _cache.SetAsync(key, dataToCache, options);
            }
            catch (Exception e)
            {
                string msg = e.Message;
            }
        }
    }
}
