using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponent.Commands;

public abstract class RunnerComponentCommand : IRequest<RunnerComponentCommandResponse>
{
    public RunnerComponentVm RunnerComponent { get; set; }
}