using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.BudgetCode.Commands;

public class BudgetCodeCommandResponse : BaseResponse
{
    public BudgetCodeVm Data { get; set; }
}