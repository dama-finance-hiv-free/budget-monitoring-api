using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.TransactionCode.Commands;

public class EditTransactionCodeCommandHandler : IRequestHandler<EditTransactionCodeCommand, TransactionCodeCommandResponse>
{
    private readonly ITransactionCodePersistence _transactionCodePersistence;
    private readonly IMapper _mapper;

    public EditTransactionCodeCommandHandler(ITransactionCodePersistence transactionCodePersistence, IMapper mapper)
    {
        _transactionCodePersistence = transactionCodePersistence;
        _mapper = mapper;
    }

    public async Task<TransactionCodeCommandResponse> Handle(EditTransactionCodeCommand request, CancellationToken cancellationToken)
    {
        var response = new TransactionCodeCommandResponse();
        var transactionCode = _mapper.Map<Domain.Entity.Budgeting.TransactionCode>(request.TransactionCode);

        var result = await _transactionCodePersistence.EditAsync(transactionCode);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<TransactionCodeVm>(result.Entity);

        return response;
    }
}