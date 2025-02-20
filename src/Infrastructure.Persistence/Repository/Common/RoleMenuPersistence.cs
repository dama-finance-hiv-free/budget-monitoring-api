using System;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class RoleMenuPersistence : RepositoryBase<RoleMenu>, IRoleMenuPersistence
{
    public RoleMenuPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<RepositoryActionResult<RoleMenuDto>> UpdateRoleMenusAsync(RoleMenuDto dto)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var existingRoleMenus = await DbSet.AsNoTracking().Where(x => x.RoleCode == dto.Role).ToArrayAsync();
            if (existingRoleMenus.Any())
            {
                foreach (var roleMenu in existingRoleMenus)
                {
                    Context.Entry(roleMenu).State = EntityState.Deleted;
                }
                var clearResult = await SaveChangesAsync();
                if (clearResult == 0)
                {
                    await tx.RollbackAsync();
                    return new RepositoryActionResult<RoleMenuDto>(null, RepositoryActionStatus.Error);
                }
            }

            var roleMenus = dto.MenuCodes.Select(x => new RoleMenu
            {
                Tenant = dto.Tenant,
                App = "01",
                RoleCode = dto.Role,
                MenuCode = x,
                Status = "01",
                CreatedOn = DateTime.UtcNow
            }).ToArray();

            var addResult = await AddManyAsync(roleMenus);
            if (addResult.Status != RepositoryActionStatus.Created)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<RoleMenuDto>(null, RepositoryActionStatus.Error);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<RoleMenuDto>(dto, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<RoleMenuDto>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<string[]> GetRoleMenuCodesAsync(string tenant, string role) =>
        await DbSet.Where(x => x.RoleCode == role).Select(x => x.MenuCode).ToArrayAsync();

    public async Task<string[]> GetUserMenusCodesAsync(string tenant, string userCode)
    {
        var userRoles = await Context.UserRoleSet.Where(x => x.Tenant == tenant && x.UsrCode == userCode)
            .Select(x => x.RoleCode)
            .ToArrayAsync();

        var userMenus = await Context.RoleMenuSet.Where(x => userRoles.Contains(x.RoleCode)).Select(x => x.MenuCode)
            .Distinct().ToArrayAsync();

        return userMenus;
    }
}
