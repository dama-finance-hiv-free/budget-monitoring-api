using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodStatus.Commands;

public abstract class RunnerPeriodStatusCommand : IRequest<RunnerPeriodStatusCommandResponse>
{
    public RunnerPeriodStatusVm RunnerPeriodStatus { get; set; }
}