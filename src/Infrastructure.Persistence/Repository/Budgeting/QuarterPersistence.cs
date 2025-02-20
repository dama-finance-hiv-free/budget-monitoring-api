using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class QuarterPersistence : RepositoryBase<Quarter>, IQuarterPersistence
{
    public QuarterPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Quarter>> AddAsync(Quarter entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastQuarter = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastQuarter == null
                ? "1".ToTwoChar()
                : (lastQuarter.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Quarter>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Quarter>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Quarter>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<Quarter[]> GetQuartersAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<Quarter> ItemToGetAsync(string tenant, string quarter) =>
        await GetFirstOrDefaultAsync(x => x.Code == quarter);

    protected override async Task<Quarter> ItemToGetAsync(Quarter quarter) =>
        await GetFirstOrDefaultAsync(x => x.Code == quarter.Code);
}