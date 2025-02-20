using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Activity;

public class ActivityService : ServiceBase<Domain.Entity.Budgeting.Activity, ActivityVm>, IActivityService
{
    private readonly IActivityPersistence _activityPersistence;
    private readonly IActivityHistoryPersistence _activityHistoryPersistence;
    private readonly IRunnerService _runnerService;
    private readonly IComponentService _componentService;
    private readonly IBranchService _branchService;
    private readonly IActivityPlanService _activityPlanService;

    private readonly ICostCategoryService _costCategoryService;
    private readonly IInterventionService _interventionService;
    private readonly IBudgetCodeService _budgetCodeService;
    private readonly ITransactionCodeService _transactionCodeService;
    private readonly ICopYearService _copYearService;
    private readonly IRegionService _regionService;
    private readonly ISiteService _siteService;
    private readonly IProjectService _projectService;
    private readonly IStrategyService _strategyService;

    private readonly IMapper _mapper;

    public ActivityService(IDataPersistence<Domain.Entity.Budgeting.Activity> persistence, IMapper mapper,
        IDistributedCache cache, IActivityPersistence activityPersistence,
        IActivityHistoryPersistence activityHistoryPersistence, IRunnerService runnerService,
        IComponentService componentService, IBranchService branchService, IActivityPlanService activityPlanService,
        ICostCategoryService costCategoryService, IInterventionService interventionService,
        IBudgetCodeService budgetCodeService, ITransactionCodeService transactionCodeService,
        ICopYearService copYearService, IRegionService regionService, ISiteService siteService,
        IProjectService projectService, IStrategyService strategyService) : base(persistence, mapper, cache)
    {
        _activityPersistence = activityPersistence;
        _activityHistoryPersistence = activityHistoryPersistence;
        _runnerService = runnerService;
        _componentService = componentService;
        _branchService = branchService;
        _activityPlanService = activityPlanService;
        _costCategoryService = costCategoryService;
        _interventionService = interventionService;
        _budgetCodeService = budgetCodeService;
        _transactionCodeService = transactionCodeService;
        _copYearService = copYearService;
        _regionService = regionService;
        _siteService = siteService;
        _projectService = projectService;
        _strategyService = strategyService;
        _mapper = mapper;
    }

    public async Task<ActivityVm[]> GetActivitiesAsync(string tenant, string region, string activityType, string branch)
    {
        var activities = await _activityPersistence.GetActivitiesAsync(tenant, region, activityType, branch);
        return _mapper.Map<ActivityVm[]>(activities);
    }

    public async Task<ActivityVm[]> GetActivitiesAsync(string tenant, string region, string activityType,
        DateTime startDate, DateTime endDate)
    {
        var activities =
            await _activityPersistence.GetActivitiesAsync(tenant, region, activityType, startDate, endDate);
        return _mapper.Map<ActivityVm[]>(activities);
    }

    public async Task<ActivityVm[]> GetActivityJournalWithHistoryAsync(string tenant, string region, string project, string activityType,
        DateTime startDate, DateTime endDate)
    {
        var activities =
            await _activityPersistence.GetActivityJournalWithHistoryAsync(tenant, region, project, activityType, startDate, endDate);
        return _mapper.Map<ActivityVm[]>(activities);
    }

    public async Task<ActivityVm[]> GetBatchActivitiesAsync(string batchCode)
    {
        var activities = await _activityHistoryPersistence.GetBatchActivitiesAsync(batchCode);
        return _mapper.Map<ActivityVm[]>(activities);
    }

    public async Task<ActivitySummaryVm[]> GetActivityHistorySummaryAsync(string tenant, string runner, string transactionCode, string activityType, string project)
    {
        //continue here with project configuration
        var activities =
            await _activityPersistence.GetActivityJournalHistoryAsync(tenant, runner, transactionCode, activityType, project);

        var distinctBatches = activities.Select(x => x.Batch).Distinct().ToArray();

        return distinctBatches.Select(x => GetActivityHistorySummaryAsync(x, activities)).Where(vm => vm != null).ToArray();
    }

    private static ActivitySummaryVm GetActivityHistorySummaryAsync(string batchCode,
        IEnumerable<Domain.Entity.Budgeting.Activity> activities)
    {
        var activitiesBatch = activities.Where(x => x.Batch == batchCode)
            .OrderBy(x => x.BatchLine).ToArray();

        var firstLine = activitiesBatch.FirstOrDefault();
        if (firstLine is null) return null;
        
        return new ActivitySummaryVm
        {
            Tenant = firstLine.Tenant,
            Batch = firstLine.Batch,
            Branch = firstLine.Branch,
            Runner = firstLine.Runner,
            TransDate = firstLine.TransDate,
            UserCode = firstLine.UserCode,
            Amount = activitiesBatch.Sum(x=>x.Amount),
            Quantity = activitiesBatch.Length,
            Region = firstLine.Region,
            Description = firstLine.Description,
            Project = firstLine.Project,
            ActivityType = firstLine.ActivityType,
            TransactionCode = firstLine.TranCode,
        };
    }

    public async Task<ActivityVm[]> GetActivityHistories(ActivityHistoryOptionsVm options)
    {
        var activities = await _activityHistoryPersistence.GetActivities(options);
        return _mapper.Map<ActivityVm[]>(activities);
    }

    public async Task<ActivityLookupSet> GetLookupSetsAsync(string tenant)
    {
        var runners = await _runnerService.GetRunnerCodesAsync(tenant);
        var components = await _componentService.GetComponentCodesAsync(tenant);
        var branches = await _branchService.GetBranchCodesAsync(tenant);
        var costCategories = await _costCategoryService.GetCostCategoryCodesAsync(tenant);
        var interventions = await _interventionService.GetInterventionCodesAsync(tenant);
        var budgetCodes = await _budgetCodeService.GetBudgetCodeCodesAsync(tenant);
        var transactionCodes = await _transactionCodeService.GetTransactionCodeCodesAsync(tenant);
        var copYears = await _copYearService.GetCopYearCodesAsync(tenant);
        var regions = await _regionService.GetRegionCodesAsync();
        var sites = await _siteService.GetSiteCodesAsync(tenant);
        var projects = await _projectService.GetProjectCodesAsync(tenant);
        var activities = await _activityPlanService.GetActivityPlanCodesAsync(tenant);
        var strategies = await _strategyService.GetStrategyCodesAsync(tenant);

        return new ActivityLookupSet
        {
            Runners = runners,
            Components = components,
            Branches = branches,
            CostCategories = costCategories,
            Interventions = interventions,
            BudgetCodes = budgetCodes,
            TranCodes = transactionCodes,
            CopYears = copYears,
            Regions = regions,
            Sites = sites,
            Projects = projects,
            Activities = activities,
            Strategies = strategies,
        };
    }

    public async Task UpdateCacheAsync(string tenant, string region, string activityType, string branch, string project)
    {
        var cacheKey = $"urn:{tenant}:{region}:{activityType}:{branch}:{typeof(ActivityVm)}";

        await UpdateCachedItemsAsync(
            () => _activityPersistence.GetActivitiesAsync(tenant, region, activityType, branch), cacheKey);
    }
}