using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class RolePersistence : RepositoryBase<Role>, IRolePersistence
{
    public RolePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Role>> AddAsync(Role entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastRole = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastRole == null
                ? "1".ToTwoChar()
                : (lastRole.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Role>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Role>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Role>(null, RepositoryActionStatus.Error, ex);
        }
    }
}