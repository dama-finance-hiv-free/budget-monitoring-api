using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SurgeActivity.Commands;

public class EditSurgeActivityCommandHandler :  IRequestHandler<EditSurgeActivityCommand, SurgeActivityCommandResponse>
{
    private readonly ISurgeActivityPersistence _siteTypePersistence;
    private readonly IMapper _mapper;

    public EditSurgeActivityCommandHandler(ISurgeActivityPersistence siteTypePersistence, IMapper mapper)
    {
        _siteTypePersistence = siteTypePersistence;
        _mapper = mapper;
    }

    public async Task<SurgeActivityCommandResponse> Handle(EditSurgeActivityCommand request, CancellationToken cancellationToken)
    {
        var response = new SurgeActivityCommandResponse();
        var surgeActivity = _mapper.Map<Domain.Entity.Budgeting.SurgeActivity>(request.SurgeActivity);

        var result = await _siteTypePersistence.EditAsync(surgeActivity);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<SurgeActivityVm>(result.Entity);

        return response;
    }
}