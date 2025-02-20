using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class TransactionCodePersistence : RepositoryBase<TransactionCode>, ITransactionCodePersistence
{
    public TransactionCodePersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public override async Task<RepositoryActionResult<TransactionCode>> AddAsync(TransactionCode entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastTransactionCode = DbSet.OrderByDescending(x => x.Code).ToArray().FirstOrDefault();
            var serial = lastTransactionCode == null
                ? "1".ToTwoChar()
                : (lastTransactionCode.Code.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.Code = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<TransactionCode>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<TransactionCode>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<TransactionCode>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<TransactionCode[]> GetTransactionCodesAsync(string tenant, string user) => await GetAllAsync();

    public async Task<TransactionCode[]> GetTransactionCodesAsync(string tenant) => await GetAllAsync();

    protected override async Task<TransactionCode> ItemToGetAsync(string tenant, string transactionCode) =>
        await GetFirstOrDefaultAsync(x => x.Code == transactionCode);

    protected override async Task<TransactionCode> ItemToGetAsync(TransactionCode transactionCode) =>
        await GetFirstOrDefaultAsync(x => x.Code == transactionCode.Code);
}