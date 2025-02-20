using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.DialogMessage.Commands;

public abstract class DialogMessageCommand : IRequest<DialogMessageCommandResponse>
{
    public DialogMessageVm DialogMessage { get; set; }
}