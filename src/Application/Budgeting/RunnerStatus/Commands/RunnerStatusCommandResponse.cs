using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.RunnerStatus.Commands;

public class RunnerStatusCommandResponse : BaseResponse
{
    public RunnerStatusVm Data { get; set; }
}