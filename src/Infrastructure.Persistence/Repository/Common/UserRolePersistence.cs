using System;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;
using Dama.Fin.Domain.Vm.Common;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class UserRolePersistence : RepositoryBase<UserRole>, IUserRolePersistence
{
    public UserRolePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<RepositoryActionResult<UserRole[]>> UpdateUserRolesAsync(UserRoleDto dto)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var existingUserRoles = await DbSet.AsNoTracking().Where(x => x.UsrCode == dto.User).ToArrayAsync();
            if (existingUserRoles.Any())
            {
                foreach (var userRole in existingUserRoles)
                {
                    Context.Entry(userRole).State = EntityState.Deleted;
                }
                var clearResult = await SaveChangesAsync();
                if (clearResult == 0)
                {
                    await tx.RollbackAsync();
                    return new RepositoryActionResult<UserRole[]>(null, RepositoryActionStatus.Error);
                }
            }

            var userRoles = dto.Roles.Select(x => new UserRole
            {
                Tenant = dto.Tenant,
                UsrCode = dto.User,
                RoleCode = x,
                Status = "01"
            }).ToArray();

            var addResult = await AddManyAsync(userRoles);
            if (addResult.Status != RepositoryActionStatus.Created)
            {
                await tx.RollbackAsync();
                return new RepositoryActionResult<UserRole[]>(null, RepositoryActionStatus.Error);
            }

            var userRolesData = await DbSet.AsNoTracking().Where(x => x.UsrCode == dto.User).ToArrayAsync();

            await tx.CommitAsync();
            return new RepositoryActionResult<UserRole[]>(userRolesData, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<UserRole[]>(null, RepositoryActionStatus.Error, ex);
        }
    }

    protected override async Task<UserRole> ItemToGetAsync(string tenant, string userRole) =>
        await GetFirstOrDefaultAsync(x => x.RoleCode == userRole);

    protected override async Task<UserRole> ItemToGetAsync(UserRole userRole) =>
        await GetFirstOrDefaultAsync(x => x.UsrCode == userRole.UsrCode && x.RoleCode == userRole.RoleCode);
}