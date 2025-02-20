using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Activity.Commands;

public class DeleteActivityCommandResponse : BaseResponse
{
    public DeletedActivityVm Data { get; set; }
}