using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetCode.Commands;

public abstract class BudgetCodeCommand : IRequest<BudgetCodeCommandResponse>
{
    public BudgetCodeVm BudgetCode { get; set; }
}