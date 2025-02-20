using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Core.Common.Core;
using Dama.Core.Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Dama.Core.Common.Data;

public abstract class RepositoryBase<TEntity, TContext> : IDataPersistence<TEntity>
    where TEntity : class, IIdentifiableEntity, new()
    where TContext : DbContext
{
    protected TContext Context;
    protected IDbConnection Db;

    protected DbSet<TEntity> DbSet { get; }

    protected RepositoryBase(TContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public virtual async Task<RepositoryActionResult<TEntity>> AddAsync(TEntity entity)
    {
        try
        {
            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            return result != 0
                ? new RepositoryActionResult<TEntity>(entity, RepositoryActionStatus.Created)
                : new RepositoryActionResult<TEntity>(entity, RepositoryActionStatus.NothingModified);
        }
        catch (Exception ex)
        {
            return new RepositoryActionResult<TEntity>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public virtual async Task<RepositoryActionResult<IEnumerable<TEntity>>> AddManyAsync(IEnumerable<TEntity> entities)
    {
        try
        {
            var enumerable = entities as TEntity[] ?? entities.ToArray();
            DbSet.AddRange(enumerable);
            var result = await SaveChangesAsync();
            return result != 0
                ? new RepositoryActionResult<IEnumerable<TEntity>>(enumerable, RepositoryActionStatus.Created)
                : new RepositoryActionResult<IEnumerable<TEntity>>(enumerable,
                    RepositoryActionStatus.NothingModified);
        }
        catch (Exception ex)
        {
            return new RepositoryActionResult<IEnumerable<TEntity>>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public virtual async Task<RepositoryActionResult<IEnumerable<TEntity>>> EditManyAsync(IEnumerable<TEntity> entities)
    {
        try
        {
            var enumerable = entities as TEntity[] ?? entities.ToArray();
            var result = await SaveChangesAsync();
            return result != 0
                ? new RepositoryActionResult<IEnumerable<TEntity>>(enumerable, RepositoryActionStatus.Created)
                : new RepositoryActionResult<IEnumerable<TEntity>>(enumerable,
                    RepositoryActionStatus.NothingModified);
        }
        catch (Exception ex)
        {
            return new RepositoryActionResult<IEnumerable<TEntity>>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public virtual async Task<RepositoryActionResult<TEntity>> DeleteAsync(TEntity entity)
    {
        try
        {
            var existingEntity = await ItemToGetAsync(entity);
            if (existingEntity == null)
                return new RepositoryActionResult<TEntity>(null, RepositoryActionStatus.NotFound);

            Context.Entry(existingEntity).State = EntityState.Detached;

            DbSet.Remove(existingEntity);

            var result = await SaveChangesAsync();
            return result > 0
                ? new RepositoryActionResult<TEntity>(entity, RepositoryActionStatus.Deleted)
                : new RepositoryActionResult<TEntity>(null, RepositoryActionStatus.NotFound);
        }
        catch (Exception ex)
        {
            return new RepositoryActionResult<TEntity>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public virtual async Task<RepositoryActionResult<TEntity>> DeleteManyAsync(Expression<Func<TEntity, bool>> where)
    {
        try
        {
            var entities = DbSet.Where(where).AsEnumerable();
            foreach (var entity in entities) DbSet.Remove(entity);

            await SaveChangesAsync();
            return new RepositoryActionResult<TEntity>(null, RepositoryActionStatus.Deleted);
        }
        catch (Exception ex)
        {
            return new RepositoryActionResult<TEntity>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public virtual async Task<RepositoryActionResult<TEntity>> EditAsync(TEntity entity)
    {
        try
        {
            var existingEntity = await ItemToGetAsync(entity);
            if (existingEntity == null)
            {
                return new RepositoryActionResult<TEntity>(null, RepositoryActionStatus.NotFound);
            }

            Context.Entry(existingEntity).State = EntityState.Detached;
            existingEntity = PropertyMapper.PropertyMapSelective(entity, existingEntity);
            DbSet.Attach(existingEntity);
            Context.Entry(existingEntity).State = EntityState.Modified;
            var result = await SaveChangesAsync();
            return result == 0
                ? new RepositoryActionResult<TEntity>(existingEntity, RepositoryActionStatus.NothingModified, null)
                : new RepositoryActionResult<TEntity>(existingEntity, RepositoryActionStatus.Updated);
        }
        catch (Exception ex)
        {
            return new RepositoryActionResult<TEntity>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public virtual async Task<TEntity[]> GetAllAsync() => await ItemsToGetAsync();

    public virtual async Task<TEntity[]> GetAllAsync(int page, int count)
    {
        return await ItemsToGetAsync(page, count);
    }

    public virtual async Task<TEntity> GetAsync(TEntity entity) => await ItemToGetAsync(entity);

    public virtual async Task<TEntity> GetAsync(string tenant, string entity) => await ItemToGetAsync(tenant, entity);

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where) =>
        await DbSet.AsNoTracking().Where(where).FirstOrDefaultAsync();

    public virtual async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> where) =>
        await DbSet.AsNoTracking().FirstOrDefaultAsync(where);

    public virtual async Task<TEntity> GetFirstOrDefaultAsync() =>
        await DbSet.AsNoTracking().FirstOrDefaultAsync();

    public virtual async Task<TEntity[]> GetManyAsync(Expression<Func<TEntity, bool>> where) =>
        await DbSet.AsNoTracking().Where(where).ToArrayAsync();

    public virtual async Task<TEntity[]> GetManyAsync(Expression<Func<TEntity, bool>> where,
        Expression<Func<TEntity, string>> orderBy) =>
        await DbSet.AsNoTracking().Where(where).OrderBy(orderBy).ToArrayAsync();

    public virtual async Task<TEntity[]> GetManyAsync(Expression<Func<TEntity, bool>> where,
        Expression<Func<TEntity, string>> orderBy, Expression<Func<TEntity, string>> thenBy) =>
        await DbSet.AsNoTracking().Where(where).OrderBy(orderBy).ThenBy(thenBy).ToArrayAsync();

    protected virtual async Task<TEntity[]> ItemsToGetAsync() => await DbSet.AsNoTracking().ToArrayAsync();
    protected virtual async Task<TEntity[]> ItemsToGetAsync(int page, int count)
    {
        return await DbSet.AsNoTracking().Skip(page*count).Take(count).ToArrayAsync();
    }

    protected virtual async Task<TEntity> ItemToGetAsync(TEntity entity) => await Task.FromResult(entity);

    protected virtual async Task<TEntity> ItemToGetAsync(string tenant, string entity) => await Task.FromResult(new TEntity());

    protected async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();

    public async Task<int> GetCountAsync() => await DbSet.CountAsync();
}