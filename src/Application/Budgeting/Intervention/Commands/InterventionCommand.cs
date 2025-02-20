using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Intervention.Commands;

public abstract class InterventionCommand : IRequest<InterventionCommandResponse>
{
    public InterventionVm Intervention { get; set; }
}