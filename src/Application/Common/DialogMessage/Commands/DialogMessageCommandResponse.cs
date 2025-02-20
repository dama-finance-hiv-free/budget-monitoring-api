using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.DialogMessage.Commands;

public class DialogMessageCommandResponse : BaseResponse
{
    public DialogMessageVm Data { get; set; }
}