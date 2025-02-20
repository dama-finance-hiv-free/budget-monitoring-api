using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Commands;

public class EditActivityCommandHandler : ActivityCommandBase,
    IRequestHandler<EditActivityCommand, ActivityCommandResponse>
{
    private readonly IActivityPersistence _activityPersistence;
    private readonly IActivityService _activityService;
    private readonly IMapper _mapper;

    public EditActivityCommandHandler(IMapper mapper, IActivityService activityService, IActivityPlanService activityPlanService, IRunnerPersistence runnerPersistence, IUserCoordinationService userCoordinationService, IActivityPersistence activityPersistence) : base(mapper, activityService, activityPlanService, runnerPersistence, userCoordinationService)
    {
        _activityPersistence = activityPersistence;
        _activityService = activityService;
        _mapper = mapper;
    }

    public async Task<ActivityCommandResponse> Handle(EditActivityCommand request, CancellationToken cancellationToken)
    {
        var (response, activity) = await ValidateActivityAsync(request, ActivityUpdateMode.Edit, cancellationToken);

        var result = await _activityPersistence.EditAsync(activity);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<ActivityVm>(result.Entity);

        await _activityService.UpdateCacheAsync(activity.Tenant, activity.Region, activity.ActivityType,
            activity.Branch, activity.Project);

        return response;
    }
}