using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.TransactionCode.Queries;

public class TransactionCodesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<TransactionCodesPaginationQuery, TransactionCodeVm[]>
{
    private readonly ITransactionCodeService _transactionCodeService;

    public TransactionCodesPaginationQueryHandler(ITransactionCodeService transactionCodeService)
    {
        _transactionCodeService = transactionCodeService;
    }

    public async Task<TransactionCodeVm[]> Handle(TransactionCodesPaginationQuery request, CancellationToken cancellationToken) =>
        await _transactionCodeService.GetAllAsync(true, request.Page, request.Count);
}
