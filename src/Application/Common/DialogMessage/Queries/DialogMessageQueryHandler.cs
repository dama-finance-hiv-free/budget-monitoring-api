using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.DialogMessage.Queries;

public class DialogMessageQueryHandler : RequestHandlerBase, IRequestHandler<DialogMessageQuery, DialogMessageVm>
{
    private readonly IDialogMessageService _dialogMessageService;

    public DialogMessageQueryHandler(IDialogMessageService dialogMessageService)
    {
        _dialogMessageService = dialogMessageService;
    }

    public async Task<DialogMessageVm> Handle(DialogMessageQuery request, CancellationToken cancellationToken) =>
        await _dialogMessageService.GetAsync(request.Tenant, request.Code);
}