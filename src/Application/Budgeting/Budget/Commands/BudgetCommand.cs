using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Commands;

public abstract class BudgetCommand : IRequest<BudgetCommandResponse>
{
    public BudgetVm Budget { get; set; }
}