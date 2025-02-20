using System.Threading.Tasks;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Domain.Contracts.Service.Budgeting;

public interface ITransactionCodeService : IServiceBase<TransactionCodeVm>
{
    Task<TransactionCodeVm[]> GetUserTransactionCodesAsync(string tenant);

    Task<string[]> GetTransactionCodeCodesAsync(string tenant);
    
}