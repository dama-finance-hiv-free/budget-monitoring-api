using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.IncludeRunner.Commands;

public abstract class IncludeRunnerCommand : IRequest<IncludeRunnerCommandResponse>
{
    public IncludeRunnerVm IncludeRunner { get; set; }
}