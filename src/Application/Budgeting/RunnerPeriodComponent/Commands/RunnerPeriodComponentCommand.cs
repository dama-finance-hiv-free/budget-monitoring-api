using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodComponent.Commands;

public abstract class RunnerPeriodComponentCommand : IRequest<RunnerPeriodComponentCommandResponse>
{
    public RunnerPeriodComponentVm RunnerPeriodComponent { get; set; }
}