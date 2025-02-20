using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Exceptions;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.Activity.Commands;

public abstract class ActivityCommandBase : RequestHandlerBase
{
    private readonly IMapper _mapper;
    private readonly IActivityService _activityService;
    private readonly IActivityPlanService _activityPlanService;
    private readonly IRunnerPersistence _runnerPersistence;
    private readonly IUserCoordinationService _userCoordinationService;

    protected ActivityCommandBase(IMapper mapper, IActivityService activityService,
        IActivityPlanService activityPlanService, IRunnerPersistence runnerPersistence,
        IUserCoordinationService userCoordinationService)
    {
        _mapper = mapper;
        _activityService = activityService;
        _activityPlanService = activityPlanService;
        _runnerPersistence = runnerPersistence;
        _userCoordinationService = userCoordinationService;
    }

    protected async Task<(ActivityCommandResponse response, Domain.Entity.Budgeting.Activity activity)>
        ValidateActivityAsync(ActivityCommand request, ActivityUpdateMode activityUpdateMode,
            CancellationToken cancellationToken)
    {
        var activityPlan = await _activityPlanService.GetActivityPlanAsync(request.Tenant, request.Activity.Activity);
        if (activityPlan == null)
            throw new ValidationException(new List<string>() { "invalid activity code" });

        if (request.Activity.Runner == null)
            throw new ValidationException(new List<string>() { "invalid runner" });

        var runner = request.Activity.ActivityType == "01"
            ? await _runnerPersistence.GetAsync(request.Tenant, request.Activity.Runner)
            : await _runnerPersistence.GetRunnerOrHistoryAsync(request.Tenant, request.Activity.Runner);

        if (runner == null)
            throw new ValidationException(new List<string>() { "invalid runner" });

        request.Activity.BudgetCode = activityPlan.BudgetCode;
        request.Activity.Intervention = activityPlan.Intervention;
        request.Activity.CostCategory = activityPlan.CostCategory;

        switch (request.Activity.Project)
        {
            case "01":
                request.Activity.Strategy = string.Empty;
                break;
            case "02":
                request.Activity.Strategy = activityPlan.Strategy;
                break;
        }

        request.Activity.TransDate = runner.StartDate;
        request.Activity.ServerDate = DateTime.UtcNow;

        var response = new ActivityCommandResponse();

        var lookupSet = await _activityService.GetLookupSetsAsync(request.Tenant);
        lookupSet.ActivityUpdateMode = activityUpdateMode;

        if (!response.Success) return (response, null);

        var entity = _mapper.Map<Domain.Entity.Budgeting.Activity>(request.Activity);

        return (response, entity);  
    }

    protected async Task<(ActivityCommandResponse response, Domain.Entity.Budgeting.Activity activity)>
        ValidateActivityAsync(ActivityCommand request, CancellationToken cancellationToken)
    {
        var activityPlan = await _activityPlanService.GetActivityPlanAsync(request.Tenant, request.Activity.Activity);
        if (activityPlan == null)
            throw new ValidationException(new List<string>() { "invalid activity code" });

        if (request.Activity.Runner == null)
            throw new ValidationException(new List<string>() { "invalid runner" });

        var runner = await _runnerPersistence.GetAsync(request.Tenant, request.Activity.Runner);

        if (runner == null)
            throw new ValidationException(new List<string>() { "invalid runner" });

        request.Activity.BudgetCode = activityPlan.BudgetCode;
        request.Activity.Intervention = activityPlan.Intervention;
        request.Activity.CostCategory = activityPlan.CostCategory;
        request.Activity.Strategy = string.Empty;
        request.Activity.TransDate = runner.StartDate;
        request.Activity.ServerDate = DateTime.UtcNow;

        var response = new ActivityCommandResponse();

        var lookupSet = await _activityService.GetLookupSetsAsync(request.Tenant);
        var userCoordination =
            await _userCoordinationService.GetUserUserCoordinationCodesAsync(request.Tenant, request.CurrentUser);

        lookupSet.UserCoordination = userCoordination;

        if (!response.Success) return (response, null);

        var entity = _mapper.Map<Domain.Entity.Budgeting.Activity>(request.Activity);

        return (response, entity);
    }
}