using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class ComponentPersistence : RepositoryBase<Component>, IComponentPersistence
{
    public ComponentPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Component>> AddAsync(Component entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastComponent = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastComponent == null
                ? "1".ToTwoChar()
                : (lastComponent.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Component>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Component>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Component>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<Component[]> GetComponentsAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<Component> ItemToGetAsync(string tenant, string component) =>
        await GetFirstOrDefaultAsync(x => x.Code == component);

    protected override async Task<Component> ItemToGetAsync(Component component) =>
        await GetFirstOrDefaultAsync(x => x.Code == component.Code);
}