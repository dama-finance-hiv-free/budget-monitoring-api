using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodComponent.Commands;

public class RunnerPeriodComponentCommandResponse : BaseResponse
{
    public RunnerPeriodComponentVm Data { get; set; }
}