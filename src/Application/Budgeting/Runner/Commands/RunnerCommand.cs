using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Runner.Commands;

public abstract class RunnerCommand : IRequest<RunnerCommandResponse>
{
    public RunnerVm Runner { get; set; }
}