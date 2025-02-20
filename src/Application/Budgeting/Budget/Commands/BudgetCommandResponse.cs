using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Budget.Commands;

public class BudgetCommandResponse : BaseResponse
{
    public BudgetVm Data { get; set; }
}