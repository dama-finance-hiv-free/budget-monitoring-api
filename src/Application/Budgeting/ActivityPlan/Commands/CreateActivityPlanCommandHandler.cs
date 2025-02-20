using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ActivityPlan.Commands;

public class CreateActivityPlanCommandHandler :
    IRequestHandler<CreateActivityPlanCommand, ActivityPlanCommandResponse>
{
    private readonly IActivityPlanPersistence _activityPlanPersistence;
    private readonly IMapper _mapper;

    public CreateActivityPlanCommandHandler(IActivityPlanPersistence activityPlanPersistence, IMapper mapper)
    {
        _activityPlanPersistence = activityPlanPersistence;
        _mapper = mapper;
    }

    public async Task<ActivityPlanCommandResponse> Handle(CreateActivityPlanCommand request, CancellationToken cancellationToken)
    {
        var response = new ActivityPlanCommandResponse();
        var activityPlan = _mapper.Map<Domain.Entity.Budgeting.ActivityPlan>(request.ActivityPlan);
        
        var result = await _activityPlanPersistence.AddAsync(activityPlan);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<ActivityPlanVm>(result.Entity);

        return response;
    }
}