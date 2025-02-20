using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class ProjectSitePersistence : RepositoryBase<ProjectSite>, IProjectSitePersistence
{
    public ProjectSitePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<ProjectSite>> AddAsync(ProjectSite entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastProjectSite = DbSet.OrderByDescending(x => x.copYear).ToArray().FirstOrDefault();
            var serial = lastProjectSite == null
                ? "1".ToTwoChar()
                : (lastProjectSite.copYear.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.copYear = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<ProjectSite>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<ProjectSite>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<ProjectSite>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<ProjectSite[]> GetProjectSitesAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<ProjectSite> ItemToGetAsync(string tenant, string projectSite) =>
        await GetFirstOrDefaultAsync(x => x.copYear == projectSite);

    protected override async Task<ProjectSite> ItemToGetAsync(ProjectSite projectSite) =>
        await GetFirstOrDefaultAsync(x => x.copYear == projectSite.copYear);
}