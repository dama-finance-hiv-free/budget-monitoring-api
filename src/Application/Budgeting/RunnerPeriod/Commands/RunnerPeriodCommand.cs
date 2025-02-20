using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Commands;

public abstract class RunnerPeriodCommand : IRequest<RunnerPeriodCommandResponse>
{
    public RunnerPeriodVm RunnerPeriod { get; set; }
}