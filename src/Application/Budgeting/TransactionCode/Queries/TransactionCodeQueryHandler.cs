using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.TransactionCode.Queries;

public class TransactionCodeQueryHandler : RequestHandlerBase, IRequestHandler<TransactionCodeQuery, TransactionCodeVm>
{
    private readonly ITransactionCodeService _transactionCodeService;

    public TransactionCodeQueryHandler(ITransactionCodeService transactionCodeService)
    {
        _transactionCodeService = transactionCodeService;
    }

    public async Task<TransactionCodeVm> Handle(TransactionCodeQuery request, CancellationToken cancellationToken) =>
        await _transactionCodeService.GetAsync(request.Code, request.Code);
}