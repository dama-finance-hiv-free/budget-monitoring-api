using System.Threading.Tasks;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Entity.Budgeting;

namespace Dama.Fin.Domain.Contracts.Persistence.Budgeting;

public interface ITransactionCodePersistence : IDataPersistence<TransactionCode>
{
   Task<TransactionCode[]> GetTransactionCodesAsync(string tenant);
    /* RepositoryActionResult<TransactionCode> SaveTransactionCodeAsync(TransactionCode site);
    RepositoryActionResult<TransactionCode> DeleteTransactionCodeAsync(string site);
    Task<RepositoryActionResult<TransactionCode>> OpenSessionAsync(TransactionCode site, string status);*/
}
