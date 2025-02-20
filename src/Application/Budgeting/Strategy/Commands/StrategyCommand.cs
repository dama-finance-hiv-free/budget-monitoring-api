using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Strategy.Commands;

public abstract class StrategyCommand : IRequest<StrategyCommandResponse>
{
    public StrategyVm Strategy { get; set; }
}