using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Commands;

public class EditOutlayCommandHandler : IRequestHandler<EditOutlayCommand, OutlayCommandResponse>
{
    private readonly IOutlayPersistence _outlayPersistence;
    private readonly IMapper _mapper;

    public EditOutlayCommandHandler(IOutlayPersistence outlayPersistence, IMapper mapper)
    {
        _outlayPersistence = outlayPersistence;
        _mapper = mapper;
    }

    public async Task<OutlayCommandResponse> Handle(EditOutlayCommand request, CancellationToken cancellationToken)
    {
        var response = new OutlayCommandResponse();
        var outlay = _mapper.Map<Domain.Entity.Budgeting.Outlay>(request.Outlay);

        var result = await _outlayPersistence.EditAsync(outlay);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<OutlayVm>(result.Entity);

        return response;
    }
}