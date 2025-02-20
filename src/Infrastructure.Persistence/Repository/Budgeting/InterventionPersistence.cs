using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class InterventionPersistence : RepositoryBase<Intervention>, IInterventionPersistence
{
    public InterventionPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Intervention>> AddAsync(Intervention entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastIntervention = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastIntervention == null
                ? "1".ToTwoChar()
                : (lastIntervention.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Intervention>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Intervention>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Intervention>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<Intervention[]> GetInterventionsAsync(string tenant) =>
        await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<Intervention> ItemToGetAsync(string tenant, string intervention) =>
        await GetFirstOrDefaultAsync(x => x.Code == intervention);

    protected override async Task<Intervention> ItemToGetAsync(Intervention intervention) =>
        await GetFirstOrDefaultAsync(x => x.Code == intervention.Code);
}