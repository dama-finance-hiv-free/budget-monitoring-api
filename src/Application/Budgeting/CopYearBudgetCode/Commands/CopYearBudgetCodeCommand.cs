using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearBudgetCode.Commands;

public abstract class CopYearBudgetCodeCommand : IRequest<CopYearBudgetCodeCommandResponse>
{
    public CopYearBudgetCodeVm CopYearBudgetCode { get; set; }
}