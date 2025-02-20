using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.RunnerComponent.Commands;

public class RunnerComponentCommandResponse : BaseResponse
{
    public RunnerComponentVm Data { get; set; }
}