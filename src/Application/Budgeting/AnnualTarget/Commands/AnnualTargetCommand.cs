using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.AnnualTarget.Commands;

public abstract class AnnualTargetCommand : IRequest<AnnualTargetCommandResponse>
{
    public AnnualTargetVm AnnualTarget { get; set; }
}