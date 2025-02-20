using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class BranchPersistence : RepositoryBase<Branch>, IBranchPersistence
{
    public BranchPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<Branch[]> GetUserBranchesAsync(string tenant, string user)
    {
        var userBranchPersistence = new UserBranchPersistence(DatabaseFactory);
        var userBranchCodes = await userBranchPersistence.GetUserBranchCodesAsync(tenant, user);
        return await GetManyAsync(x => userBranchCodes.Contains(x.Code) && x.Tenant == tenant);
    }
    
    public async Task<Branch[]> GetBranchesAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    public async Task<Branch> GetBranchAsync(string tenant, string code) =>
        await DbSet.FirstOrDefaultAsync(x => x.Tenant == tenant && x.Code == code);

    public override async Task<RepositoryActionResult<Branch>> AddAsync(Branch entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastBranch = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastBranch == null
                ? "1".ToTwoChar()
                : (lastBranch.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Branch>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Branch>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Branch>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<string[]> GetBranchCodesAsync() => await DbSet.Select(x => x.Code).ToArrayAsync();

    protected override async Task<Branch> ItemToGetAsync(string tenant, string branch) =>
        await GetFirstOrDefaultAsync(x => x.Code == branch);

    protected override async Task<Branch> ItemToGetAsync(Branch branch) =>
        await GetFirstOrDefaultAsync(x => x.Code == branch.Code);
}