using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodStatus.Commands;

public class RunnerPeriodStatusCommandResponse : BaseResponse
{
    public RunnerPeriodStatusVm Data { get; set; }
}