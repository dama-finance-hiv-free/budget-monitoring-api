using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Runner.Commands;

public class RunnerCommandResponse : BaseResponse
{
    public RunnerVm Data { get; set; }
}