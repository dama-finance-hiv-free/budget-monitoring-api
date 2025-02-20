using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.TransactionCode.Commands;

public abstract class TransactionCodeCommand : IRequest<TransactionCodeCommandResponse>
{
    public TransactionCodeVm TransactionCode { get; set; }
}