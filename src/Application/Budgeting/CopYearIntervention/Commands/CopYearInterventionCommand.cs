using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearIntervention.Commands;

public abstract class CopYearInterventionCommand : IRequest<CopYearInterventionCommandResponse>
{
    public CopYearInterventionVm CopYearIntervention { get; set; }
}