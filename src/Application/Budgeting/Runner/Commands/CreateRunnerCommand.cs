using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Runner.Commands;

public class CreateRunnerCommand : IRequest<RunnerCommandResponse>
{
    public RunnerVm Runner { get; set; }
    public string Tenant { get; set; }
}