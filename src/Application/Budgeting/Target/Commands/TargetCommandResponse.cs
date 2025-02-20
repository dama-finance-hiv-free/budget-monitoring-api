using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Target.Commands;

public class TargetCommandResponse : BaseResponse
{
    public TargetVm Data { get; set; }
}