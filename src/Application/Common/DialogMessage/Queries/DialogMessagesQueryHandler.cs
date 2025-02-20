using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.DialogMessage.Queries;

public class DialogMessagesQueryHandler : RequestHandlerBase, IRequestHandler<DialogMessagesQuery, DialogMessageVm[]>
{
    private readonly IDialogMessageService _dialogMessageService;

    public DialogMessagesQueryHandler(IDialogMessageService dialogMessageService)
    {
        _dialogMessageService = dialogMessageService;
    }

    public async Task<DialogMessageVm[]> Handle(DialogMessagesQuery request, CancellationToken cancellationToken) => 
        await _dialogMessageService.GetAllAsync(true);
}