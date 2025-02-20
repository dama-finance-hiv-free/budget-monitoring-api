using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Component.Commands;

public class ComponentCommandResponse : BaseResponse
{
    public ComponentVm Data { get; set; }
}