using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.RunnerComponentHistory.Commands;

public class RunnerComponentHistoryCommandResponse : BaseResponse
{
    public RunnerComponentHistoryVm Data { get; set; }
}