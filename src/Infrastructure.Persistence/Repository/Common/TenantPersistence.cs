using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class TenantPersistence : RepositoryBase<Tenant>, ITenantPersistence
{
    public TenantPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Tenant>> AddAsync(Tenant entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastTenant = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastTenant == null
                ? "1".ToTwoChar()
                : (lastTenant.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Tenant>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Tenant>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Tenant>(null, RepositoryActionStatus.Error, ex);
        }
    }

    protected override async Task<Tenant> ItemToGetAsync(Tenant tenant) =>
        await GetFirstOrDefaultAsync(x => x.Code == tenant.Code);
}