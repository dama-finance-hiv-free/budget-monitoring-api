using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.CopYearBudgetCode.Commands;

public class CopYearBudgetCodeCommandResponse : BaseResponse
{
    public CopYearBudgetCodeVm Data { get; set; }
}