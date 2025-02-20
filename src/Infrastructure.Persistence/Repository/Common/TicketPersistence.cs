using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Entity.Common;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Common;

public class TicketPersistence : RepositoryBase<Ticket>, ITicketPersistence
{
    public TicketPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<Ticket>> AddAsync(Ticket entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastTicket = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastTicket == null
                ? "1".ToTwoChar()
                : (lastTicket.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Ticket>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Ticket>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Ticket>(null, RepositoryActionStatus.Error, ex);
        }
    }

    protected override async Task<Ticket> ItemToGetAsync(string tenant, string ticket) =>
        await GetFirstOrDefaultAsync(x => x.Code == ticket);

    protected override async Task<Ticket> ItemToGetAsync(Ticket ticket) =>
        await GetFirstOrDefaultAsync(x => x.Code == ticket.Code);
}
