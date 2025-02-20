using System;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class UserCoordinationPersistence : RepositoryBase<UserCoordination>, IUserCoordinationPersistence
{
    public UserCoordinationPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<RepositoryActionResult<UserCoordination[]>> UpdateUserCoordination(UserCoordination dto)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastUserCoordination = await DbSet.AsNoTracking().Where(x => x.User == dto.User).ToArrayAsync();
            if (lastUserCoordination.Any())
            {
                foreach (var userCoord in lastUserCoordination)
                {
                    Context.Entry(userCoord).State = EntityState.Deleted;
                }
                var clearResult = await SaveChangesAsync();
                if (clearResult == 0)
                {
                    await tx.RollbackAsync();
                    return new RepositoryActionResult<UserCoordination[]>(null, RepositoryActionStatus.Error);
                }
            }
            string[] Coordinations = dto.Coordination.Split(",");
            var userCoordinations = Coordinations.Select(x => new UserCoordination
            {
                User = dto.User,
                Coordination = x,
                CreatedOn= DateTime.UtcNow,
            }).ToArray();

            var addResult = await AddManyAsync(userCoordinations);
            var returnDataDto = await DbSet.AsNoTracking().Where(x => x.User == dto.User).ToArrayAsync();
            if (addResult.Status != RepositoryActionStatus.Created)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<UserCoordination[]>(null, RepositoryActionStatus.Error);
            }
            await tx.CommitAsync();
            return new RepositoryActionResult<UserCoordination[]>(returnDataDto, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<UserCoordination[]>(null, RepositoryActionStatus.Error, ex);
        }
    }

    //public override async Task<RepositoryActionResult<UserCoordination>> AddAsync(UserCoordination entity)
    //{
    //    await using var tx = await Context.Database.BeginTransactionAsync();
    //    try
    //    {
    //        var lastUserCoordination = DbSet.OrderByDescending(x => x.User).ToArray().FirstOrDefault();
    //        var serial = lastUserCoordination == null
    //            ? "1".ToTwoChar()
    //            : (lastUserCoordination.User.ToNumValue() + 1)
    //            .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
    //        entity.User = serial;

    //        DbSet.Add(entity);
    //        var result = await SaveChangesAsync();
    //        if (result == 0)
    //        {
    //            return new RepositoryActionResult<UserCoordination>(entity, RepositoryActionStatus.NothingModified);
    //        }

    //        await tx.CommitAsync();
    //        return new RepositoryActionResult<UserCoordination>(entity, RepositoryActionStatus.Created);
    //    }
    //    catch (Exception ex)
    //    {
    //        await tx.RollbackAsync();
    //        return new RepositoryActionResult<UserCoordination>(null, RepositoryActionStatus.Error, ex);
    //    }
    //}

    public async Task<UserCoordination[]> GetUserCoordinationAsync(string tenant, string user) =>
        await DbSet.Where(x => x.User == user).ToArrayAsync();

    public async Task<UserCoordination[]> GetUserCoordinationAsync(string tenant) => await GetAllAsync();

    protected override async Task<UserCoordination> ItemToGetAsync(string tenant, string userCoordination) =>
        await GetFirstOrDefaultAsync(x => x.User == userCoordination);

    protected override async Task<UserCoordination> ItemToGetAsync(UserCoordination userCoordination) =>
        await GetFirstOrDefaultAsync(x => x.User == userCoordination.User);
}