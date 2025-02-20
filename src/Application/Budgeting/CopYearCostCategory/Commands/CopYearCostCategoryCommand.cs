using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearCostCategory.Commands;

public abstract class CopYearCostCategoryCommand : IRequest<CopYearCostCategoryCommandResponse>
{
    public CopYearCostCategoryVm CopYearCostCategory { get; set; }
}