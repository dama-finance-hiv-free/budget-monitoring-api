using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Quarter.Commands;

public abstract class QuarterCommand : IRequest<QuarterCommandResponse>
{
    public QuarterVm Quarter { get; set; }
}