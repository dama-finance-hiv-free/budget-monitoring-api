using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.TransactionCode.Commands;

public class TransactionCodeCommandResponse : BaseResponse
{
    public TransactionCodeVm Data { get; set; }
}