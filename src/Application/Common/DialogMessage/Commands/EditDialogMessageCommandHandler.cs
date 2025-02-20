using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.DialogMessage.Commands;

public class EditDialogMessageCommandHandler : IRequestHandler<EditDialogMessageCommand, DialogMessageCommandResponse>
{
    private readonly IDialogMessagePersistence _dialogMessagePersistence;
    private readonly IMapper _mapper;

    public EditDialogMessageCommandHandler(IDialogMessagePersistence dialogMessagePersistence, IMapper mapper)
    {
        _dialogMessagePersistence = dialogMessagePersistence;
        _mapper = mapper;
    }

    public async Task<DialogMessageCommandResponse> Handle(EditDialogMessageCommand request, CancellationToken cancellationToken)
    {
        var response = new DialogMessageCommandResponse();
        var dialogMessage = _mapper.Map<Domain.Entity.Common.DialogMessage>(request.DialogMessage);

        var result = await _dialogMessagePersistence.EditAsync(dialogMessage);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<DialogMessageVm>(result.Entity);

        return response;
    }
}