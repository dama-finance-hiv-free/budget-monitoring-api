using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerStatus.Commands;

public abstract class RunnerStatusCommand : IRequest<RunnerStatusCommandResponse>
{
    public RunnerStatusVm RunnerStatus { get; set; }
}