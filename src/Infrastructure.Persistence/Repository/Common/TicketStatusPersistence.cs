using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class TicketStatusPersistence : RepositoryBase<TicketStatus>, ITicketStatusPersistence
{
    public TicketStatusPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<TicketStatus>> AddAsync(TicketStatus entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastTicketStatus = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastTicketStatus == null
                ? "1".ToTwoChar()
                : (lastTicketStatus.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<TicketStatus>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<TicketStatus>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<TicketStatus>(null, RepositoryActionStatus.Error, ex);
        }
    }

    protected override async Task<TicketStatus> ItemToGetAsync(string tenant, string ticketStatus) =>
        await GetFirstOrDefaultAsync(x => x.Code == ticketStatus);

    protected override async Task<TicketStatus> ItemToGetAsync(TicketStatus ticketStatus) =>
        await GetFirstOrDefaultAsync(x => x.Code == ticketStatus.Code);
}
