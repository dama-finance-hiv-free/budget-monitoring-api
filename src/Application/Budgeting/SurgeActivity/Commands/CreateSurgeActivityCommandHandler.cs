using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.SurgeActivity.Commands;

public class CreateSurgeActivityCommandHandler : IRequestHandler<CreateSurgeActivityCommand, SurgeActivityCommandResponse>
{
    private readonly ISurgeActivityPersistence _siteTypePersistence;
    private readonly IMapper _mapper;

    public CreateSurgeActivityCommandHandler(ISurgeActivityPersistence siteTypePersistence, IMapper mapper)
    {
        _siteTypePersistence = siteTypePersistence;
        _mapper = mapper;
    }

    public async Task<SurgeActivityCommandResponse> Handle(CreateSurgeActivityCommand request, CancellationToken cancellationToken)
    {
        var response = new SurgeActivityCommandResponse();
        var surgeActivity = _mapper.Map<Domain.Entity.Budgeting.SurgeActivity>(request.SurgeActivity);

        var result = await _siteTypePersistence.AddAsync(surgeActivity);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<SurgeActivityVm>(result.Entity);

        return response;
    }
}