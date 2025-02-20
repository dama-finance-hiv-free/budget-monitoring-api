using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Core;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Service;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application;

public abstract class ServiceBase<TEntity, TModel> : ServiceBase, IServiceBase<TModel> 
    where TEntity : class, IIdentifiableEntity, new()
    where TModel : class, IEntityBase, new()
{
    private readonly IDataPersistence<TEntity> _persistence;
    private readonly IMapper _mapper;
    private readonly IDistributedCache _cache;

    protected ServiceBase(IDataPersistence<TEntity> persistence, IMapper mapper, IDistributedCache cache)
    {
        _persistence = persistence;
        _mapper = mapper;
        _cache = cache;
    }

    public virtual async Task<TModel[]> GetAllAsync(bool bypassCache = false)
    {
        var key = GetCacheKey();

        TModel[] models;

        if (_cache == null)
            return await GetItemsAsync();

        var cachedData = await _cache.GetAsync(key);
        if (cachedData != null)
        {
            var cachedDataString = Encoding.UTF8.GetString(cachedData);
            models = JsonSerializer.Deserialize<TModel[]>(cachedDataString);
        }
        else
        {
            models = await GetItemsAsync();

            var cachedDataString = JsonSerializer.Serialize(models);
            var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(3));

            await _cache.SetAsync(key, dataToCache, options);
        }

        return models;
    }

    public virtual async Task<TModel[]> GetCachedItemsAsync(Func<Task<TEntity[]>> getItemsAsync,
        int absoluteExpiration = 5, int slidingExpiration = 3, bool bypassCache = false)
    {
        var cacheKey = $"urn:{typeof(TModel)}";

        return await GetCachedItemsAsync(getItemsAsync, cacheKey, absoluteExpiration, slidingExpiration, bypassCache);
    }

    public virtual async Task<TModel[]> GetCachedItemsAsync(Func<Task<TEntity[]>> getItemsAsync, string cacheKey,
        int absoluteExpiration = 5, int slidingExpiration = 3, bool bypassCache = false)
    {
        TModel[] models;

        if (_cache == null)
        {
            var entities = await getItemsAsync.Invoke();
            return _mapper.Map<TModel[]>(entities);
        }

        var cachedData = await _cache.GetAsync(cacheKey);
        if (cachedData != null)
        {
            var cachedDataString = Encoding.UTF8.GetString(cachedData);
            models = JsonSerializer.Deserialize<TModel[]>(cachedDataString);
        }
        else
        {
            var entities = await getItemsAsync.Invoke();
            models = _mapper.Map<TModel[]>(entities);
            if (models.Length == 0)
                return models;

            var cachedDataString = JsonSerializer.Serialize(models);
            var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(absoluteExpiration))
                .SetSlidingExpiration(TimeSpan.FromMinutes(slidingExpiration));

            await _cache.SetAsync(cacheKey, dataToCache, options);
        }

        return models;
    }

    public virtual async Task UpdateCachedItemsAsync(Func<Task<TEntity[]>> getItemsAsync, string cacheKey,
        int absoluteExpiration = 5, int slidingExpiration = 3, bool bypassCache = false)
    {
        if (_cache == null)
            return;

        var cachedData = await _cache.GetAsync(cacheKey);
        if (cachedData != null) await _cache.RemoveAsync(cacheKey);

        var entities = await getItemsAsync.Invoke();
        var models = _mapper.Map<TModel[]>(entities);

        var cachedDataString = JsonSerializer.Serialize(models);
        var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

        var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(DateTime.Now.AddMinutes(absoluteExpiration))
            .SetSlidingExpiration(TimeSpan.FromMinutes(slidingExpiration));

        await _cache.SetAsync(cacheKey, dataToCache, options);
    }

    private static string GetCacheKey()
    {
        return $"urn:{typeof(TModel)}";
    }

    private async Task<TModel[]> GetItemsAsync()
    {
        var entities = await _persistence.GetAllAsync();
        return _mapper.Map<TModel[]>(entities);
    }

    public virtual async Task<TModel> GetAsync(string tenant, string code)
    {
        var entity = await _persistence.GetAsync(tenant, code);
        return _mapper.Map<TModel>(entity);
    }

    public virtual async Task<RepositoryActionResult<TModel>> AddAsync(TModel model)
    {
        var actionResult = await _persistence.AddAsync(_mapper.Map<TEntity>(model));
        return GetRepositoryActionResult(model,
            () => new RepositoryActionResult<TModel>(_mapper.Map<TModel>(actionResult.Entity), actionResult.Status));
    }

    public virtual async Task<RepositoryActionResult<TModel[]>> AddManyAsync(TModel[] models)
    {
        var actionResult = await _persistence.AddManyAsync(_mapper.Map<TEntity[]>(models));
        return new RepositoryActionResult<TModel[]>(_mapper.Map<TModel[]>(actionResult.Entity),
            actionResult.Status);
    }

    public virtual async Task<RepositoryActionResult<TModel>> EditAsync(TModel model)
    {
        var actionResult = await _persistence.EditAsync(_mapper.Map<TEntity>(model));
        return GetRepositoryActionResult(model,
            () => new RepositoryActionResult<TModel>(_mapper.Map<TModel>(actionResult.Entity), actionResult.Status));
    }

    public virtual async Task<RepositoryActionResult<TModel>> DeleteAsync(TModel model)
    {
        var actionResult = await _persistence.DeleteAsync(_mapper.Map<TEntity>(model));
        return GetRepositoryActionResult(model,
            () => new RepositoryActionResult<TModel>(_mapper.Map<TModel>(actionResult.Entity), actionResult.Status));
    }

    public RepositoryActionResult<TModel> GetRepositoryActionResult(TModel value,
        Func<RepositoryActionResult<TModel>> codeToExecute)
    {
        try
        {
            return codeToExecute.Invoke();
        }
        catch (Exception ex)
        {
            return new RepositoryActionResult<TModel>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<TModel[]> GetAllAsync(bool bypassCache, int page, int count)
    {
        const string key = $"urn:{nameof(TModel)}";

        if (!bypassCache)
        {
            var rtn = CacheEngine.Get<TModel[]>(key);
            if (rtn != null) return rtn.Skip(page*count).Take(count).ToArray();
        }

        var models = await _persistence.GetAllAsync(page, count);
        var result = _mapper.Map<TModel[]>(models);

        CacheEngine.Add(key, result, 0);

        return result;
    }

    public async Task<int> GetCount(bool bypassCache)
    {
        const string key = $"urn:{nameof(TModel)}";

        if (bypassCache) return await _persistence.GetCountAsync();
        var rtn = CacheEngine.Get<TModel[]>(key);
        if (rtn != null) return rtn.Count();

        return await _persistence.GetCountAsync(); 
    }
}