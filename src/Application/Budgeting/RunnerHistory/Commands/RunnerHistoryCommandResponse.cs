using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.RunnerHistory.Commands;

public class RunnerHistoryCommandResponse : BaseResponse
{
    public RunnerHistoryVm Data { get; set; }
}