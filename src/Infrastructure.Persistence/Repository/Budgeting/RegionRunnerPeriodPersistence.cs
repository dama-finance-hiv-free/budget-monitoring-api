using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class RegionRunnerPeriodPersistence : RepositoryBase<RegionRunnerPeriod>, IRegionRunnerPeriodPersistence
{
    public RegionRunnerPeriodPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<RegionRunnerPeriod>> AddAsync(RegionRunnerPeriod entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastRegionRunnerPeriod = DbSet.OrderByDescending(x => x.Region).ToArray().FirstOrDefault();
            var serial = lastRegionRunnerPeriod == null
                ? "1".ToTwoChar()
                : (lastRegionRunnerPeriod.Region.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Region = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<RegionRunnerPeriod>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<RegionRunnerPeriod>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<RegionRunnerPeriod>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<RegionRunnerPeriod[]> GetRegionRunnerPeriodsAsync(string tenant, string user)
    {
        return await GetManyAsync(x => x.Tenant == tenant);
    }

    public async Task<RegionRunnerPeriod[]> GetRegionRunnerPeriodsAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<RegionRunnerPeriod> ItemToGetAsync(string tenant, string regionRunnerPeriod) =>
        await GetFirstOrDefaultAsync(x => x.Region == regionRunnerPeriod);

    protected override async Task<RegionRunnerPeriod> ItemToGetAsync(RegionRunnerPeriod regionRunnerPeriod) =>
        await GetFirstOrDefaultAsync(x => x.Region == regionRunnerPeriod.Region);
}