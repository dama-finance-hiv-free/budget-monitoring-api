using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CostCategory.Commands;

public abstract class CostCategoryCommand : IRequest<CostCategoryCommandResponse>
{
    public CostCategoryVm CostCategory { get; set; }
}