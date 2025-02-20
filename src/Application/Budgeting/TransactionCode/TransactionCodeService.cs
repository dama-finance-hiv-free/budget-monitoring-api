using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.TransactionCode;

public class TransactionCodeService : ServiceBase<Domain.Entity.Budgeting.TransactionCode, TransactionCodeVm>,
    ITransactionCodeService
{
    private readonly ITransactionCodePersistence _transactionCodePersistence;

    public TransactionCodeService(IDataPersistence<Domain.Entity.Budgeting.TransactionCode> persistence, IMapper mapper,
        IDistributedCache cache, ITransactionCodePersistence transactionCodePersistence) : base(persistence, mapper,
        cache)
    {
        _transactionCodePersistence = transactionCodePersistence;
    }

    public async Task<TransactionCodeVm[]> GetUserTransactionCodesAsync(string tenant)
        => await GetCachedItemsAsync(() => _transactionCodePersistence.GetTransactionCodesAsync(tenant));
    


    public async Task<string[]> GetTransactionCodeCodesAsync(string tenant)
    {
        var transactionCodeCodes = await GetUserTransactionCodesAsync(tenant);
        return transactionCodeCodes.Select(x => x.Code).ToArray();
    }
}