using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponentHistory.Commands;

public abstract class RunnerComponentHistoryCommand : IRequest<RunnerComponentHistoryCommandResponse>
{
    public RunnerComponentHistoryVm RunnerComponentHistory { get; set; }
}