using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Commands;

public class CreateActivityHistoryCommandHandler : IRequestHandler<CreateActivityHistoryCommand, ActivityCommandResponse>
{
    private readonly IActivityHistoryPersistence _activityHistoryPersistence;
    private readonly IMapper _mapper;

    public CreateActivityHistoryCommandHandler(IActivityHistoryPersistence activityHistoryPersistence, IMapper mapper)
    {
        _activityHistoryPersistence = activityHistoryPersistence;
        _mapper = mapper;
    }

    public async Task<ActivityCommandResponse> Handle(CreateActivityHistoryCommand request, CancellationToken cancellationToken)
    {
        var response = new ActivityCommandResponse();
        var activityHistory = _mapper.Map<Domain.Entity.Budgeting.ActivityHistory>(request.ActivityHistory);

        var result = await _activityHistoryPersistence.AddAsync(activityHistory);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<ActivityVm>(result.Entity);

        return response;
    }
}