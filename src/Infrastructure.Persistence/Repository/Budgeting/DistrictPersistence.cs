using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class DistrictPersistence : RepositoryBase<District>, IDistrictPersistence
{
    public DistrictPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<District>> AddAsync(District entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastDistrict = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastDistrict == null
                ? "1".ToTwoChar()
                : (lastDistrict.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<District>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<District>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<District>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<District[]> GetDistrictsAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<District> ItemToGetAsync(string tenant, string district) =>
        await GetFirstOrDefaultAsync(x => x.Code == district);

    protected override async Task<District> ItemToGetAsync(District district) =>
        await GetFirstOrDefaultAsync(x => x.Code == district.Code);
}