using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.IncludeRunner.Commands;

public class IncludeRunnerCommandResponse : BaseResponse
{
    public IncludeRunnerVm Data { get; set; }
}