using System;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class UserBranchPersistence : RepositoryBase<UserBranch>, IUserBranchPersistence
{
    public UserBranchPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<string[]> GetUserBranchCodesAsync(string tenant, string user)
    {
        var userBranchCodes = await Context.UserBranchSet.AsNoTracking()
            .Where(x => x.Tenant == tenant && x.UsrCode == user)
            .Select(x => x.BranchCode).ToArrayAsync();
        return userBranchCodes;
    }

    public async Task<string> GetUserDefaultBranchAsync(string tenant, string user)
    {
        var defaultBranch = string.Empty;

        var userBranchCodes = await Context.UserBranchSet.AsNoTracking()
            .Where(x => x.Tenant == tenant && x.UsrCode == user && x.IsDefault == "01")
            .Select(x => x.BranchCode).ToArrayAsync();

        if (userBranchCodes.Any())
        {
            defaultBranch = userBranchCodes.FirstOrDefault();
        }

        return defaultBranch;
    }

    public async Task<RepositoryActionResult<UserBranch[]>> UpdateUserBranchesAsync(UserBranchDto dto)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var existingUserBranches = await DbSet.AsNoTracking().Where(x => x.UsrCode == dto.User).ToArrayAsync();
            if (existingUserBranches.Any())
            {
                foreach (var userBranch in existingUserBranches)
                {
                    Context.Entry(userBranch).State = EntityState.Deleted;
                }
                var clearResult = await SaveChangesAsync();
                if (clearResult == 0)
                {
                    await tx.RollbackAsync();
                    return new RepositoryActionResult<UserBranch[]>(null, RepositoryActionStatus.Error);
                }
            }

            var userBranches = dto.Branches.Select(x => new UserBranch
            {
                Tenant = dto.Tenant,
                UsrCode = dto.User,
                BranchCode = x,
                IsDefault = "02"
            }).ToArray();

            var addResult = await AddManyAsync(userBranches);
            if (addResult.Status != RepositoryActionStatus.Created)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<UserBranch[]>(null, RepositoryActionStatus.Error);
            }

            var userRolesData = await DbSet.AsNoTracking().Where(x => x.UsrCode == dto.User).ToArrayAsync();

            await tx.CommitAsync();
            return new RepositoryActionResult<UserBranch[]>(userRolesData, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<UserBranch[]>(null, RepositoryActionStatus.Error, ex);
        }
    }
}