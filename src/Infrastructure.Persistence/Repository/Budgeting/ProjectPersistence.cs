using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class ProjectPersistence : RepositoryBase<Project>, IProjectPersistence
{
    public ProjectPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Project>> AddAsync(Project entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastProject = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastProject == null
                ? "1".ToTwoChar()
                : (lastProject.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Project>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Project>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Project>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<Project[]> GetProjectsAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<Project> ItemToGetAsync(string tenant, string project) =>
        await GetFirstOrDefaultAsync(x => x.Code == project);

    protected override async Task<Project> ItemToGetAsync(Project project) =>
        await GetFirstOrDefaultAsync(x => x.Code == project.Code);
}