using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.TransactionCode.Queries;

public class TransactionCodesQueryHandler : RequestHandlerBase, IRequestHandler<TransactionCodesQuery, TransactionCodeVm[]>
{
    private readonly ITransactionCodeService _transactionCodeService;

    public TransactionCodesQueryHandler(ITransactionCodeService transactionCodeService)
    {
        _transactionCodeService = transactionCodeService;
    }

    public async Task<TransactionCodeVm[]> Handle(TransactionCodesQuery request, CancellationToken cancellationToken) => 
        await _transactionCodeService.GetAllAsync(true);
}
