using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.TransactionCode.Commands;

public class CreateTransactionCodeCommandHandler :  IRequestHandler<CreateTransactionCodeCommand, TransactionCodeCommandResponse>
{
    private readonly ITransactionCodePersistence _transactionCodePersistence;
    private readonly IMapper _mapper;

    public CreateTransactionCodeCommandHandler(ITransactionCodePersistence transactionCodePersistence, IMapper mapper)
    {
        _transactionCodePersistence = transactionCodePersistence;
        _mapper = mapper;
    }

    public async Task<TransactionCodeCommandResponse> Handle(CreateTransactionCodeCommand request, CancellationToken cancellationToken)
    {
        var response = new TransactionCodeCommandResponse();
        var transactionCode = _mapper.Map<Domain.Entity.Budgeting.TransactionCode>(request.TransactionCode);

        var result = await _transactionCodePersistence.AddAsync(transactionCode);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<TransactionCodeVm>(result.Entity);

        return response;
    }
}