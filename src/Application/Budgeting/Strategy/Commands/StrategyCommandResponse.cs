using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Strategy.Commands;

public class StrategyCommandResponse : BaseResponse
{
    public StrategyVm Data { get; set; }
}