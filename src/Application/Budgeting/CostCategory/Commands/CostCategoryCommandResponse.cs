using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.CostCategory.Commands;

public class CostCategoryCommandResponse : BaseResponse
{
    public CostCategoryVm Data { get; set; }
}