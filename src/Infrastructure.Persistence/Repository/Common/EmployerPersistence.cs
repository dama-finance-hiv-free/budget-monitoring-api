using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class EmployerPersistence : RepositoryBase<Employer>, IEmployerPersistence
{
    public EmployerPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Employer>> AddAsync(Employer entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastEmployer = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastEmployer == null
                ? "1".ToTwoChar()
                : (lastEmployer.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Employer>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Employer>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Employer>(null, RepositoryActionStatus.Error, ex);
        }
    }

    protected override async Task<Employer> ItemToGetAsync(string tenant, string employer) =>
        await GetFirstOrDefaultAsync(x => x.Code == employer);

    protected override async Task<Employer> ItemToGetAsync(Employer employer) =>
        await GetFirstOrDefaultAsync(x => x.Code == employer.Code);
}