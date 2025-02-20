using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.TransactionCode.Queries;

public class TransactionCodeCountQueryHandler : RequestHandlerBase, IRequestHandler<TransactionCodeCountQuery, int>
{
    private readonly ITransactionCodeService _transactionCodeService;

    public TransactionCodeCountQueryHandler(ITransactionCodeService transactionCodeService)
    {
        _transactionCodeService = transactionCodeService;
    }

    public async Task<int> Handle(TransactionCodeCountQuery request, CancellationToken cancellationToken) =>
        await _transactionCodeService.GetCount(true);
}