using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerHistory.Commands;

public abstract class RunnerHistoryCommand : IRequest<RunnerHistoryCommandResponse>
{
    public RunnerHistoryVm RunnerHistory { get; set; }
}