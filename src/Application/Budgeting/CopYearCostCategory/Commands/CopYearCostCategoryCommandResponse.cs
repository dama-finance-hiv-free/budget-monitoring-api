using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.CopYearCostCategory.Commands;

public class CopYearCostCategoryCommandResponse : BaseResponse
{
    public CopYearCostCategoryVm Data { get; set; }
}