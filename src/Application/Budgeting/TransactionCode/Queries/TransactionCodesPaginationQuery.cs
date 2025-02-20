using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.TransactionCode.Queries;

public class TransactionCodesPaginationQuery : IRequest<TransactionCodeVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}