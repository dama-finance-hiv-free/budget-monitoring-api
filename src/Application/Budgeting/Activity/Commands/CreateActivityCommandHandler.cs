using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Commands;

public class CreateActivityCommandHandler : ActivityCommandBase,
    IRequestHandler<CreateActivityCommand, ActivityCommandResponse>
{
    private readonly IActivityPersistence _activityPersistence;
    private readonly IActivityService _activityService;
    private readonly IMapper _mapper;

    public CreateActivityCommandHandler(IActivityService activityService, IActivityPlanService activityPlanService,
        IRunnerPersistence runnerPersistence, IUserCoordinationService userCoordinationService,
        IActivityPersistence activityPersistence, IMapper mapper) : base(mapper, activityService, activityPlanService,
        runnerPersistence, userCoordinationService)
    {
        _activityPersistence = activityPersistence;
        _activityService = activityService;
        _mapper = mapper;
    }

    public async Task<ActivityCommandResponse> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var (response, activity) = await ValidateActivityAsync(request, ActivityUpdateMode.Add, cancellationToken);

        var result = await _activityPersistence.AddAsync(activity);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<ActivityVm>(result.Entity);

        //_ = Task.Run(async () =>
        //{
        //    await _activityCacheService.UpdateCacheAsync(activity.Tenant, activity.Region, activity.ActivityType,
        //        activity.Branch);
        //}, cancellationToken);

        await _activityService.UpdateCacheAsync(activity.Tenant, activity.Region, activity.ActivityType,
            activity.Branch, activity.Project);

        return response;
    }
}