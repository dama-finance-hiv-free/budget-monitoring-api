using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Commands;

public class RunnerPeriodCommandResponse : BaseResponse
{
    public RunnerPeriodVm Data { get; set; }
}