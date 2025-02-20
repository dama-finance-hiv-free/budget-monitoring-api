using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.AnnualTarget.Commands;

public class AnnualTargetCommandResponse : BaseResponse
{
    public AnnualTargetVm Data { get; set; }
}