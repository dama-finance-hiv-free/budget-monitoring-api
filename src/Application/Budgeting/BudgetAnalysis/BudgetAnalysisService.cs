using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.BudgetAnalysis;

public class BudgetAnalysisService : ServiceBase, IBudgetAnalysisService
{
    private readonly IInterventionService _interventionService;
    private readonly ICostCategoryService _costCategoryService;
    private readonly IActivityService _activityService;
    private readonly ISiteService _siteService;
    private readonly ISurgeActivityService _surgeActivityService;

    public BudgetAnalysisService(IInterventionService interventionService, ICostCategoryService costCategoryService,
        IActivityService activityService, ISiteService siteService, ISurgeActivityService surgeActivityService)
    {
        _interventionService = interventionService;
        _costCategoryService = costCategoryService;
        _activityService = activityService;
        _siteService = siteService;
        _surgeActivityService = surgeActivityService;
    }

    public async Task<BudgetAnalysisVm[]> GetBudgetAnalysisCostCategoryAsync(BudgetAnalysisOptions options)
    {
        var costCategories = await _costCategoryService.GetCostCategoriesAsync(options.Tenant);

        var activities =
            await _activityService.GetActivityJournalWithHistoryAsync(options.Tenant, options.Region, options.Project, options.ActivityType,
                options.StartDate.ToUtcDate(), options.EndDate.ToUtcDate());

        var filteredActivities = new List<ActivityVm>(activities) { };

        if (options.isSurge)
        {
            var surgeActivities = await _surgeActivityService.GetAllAsync(bypassCache: true);
            var surgeActivityCodes = surgeActivities.Select(x => x.Code).ToArray();
            filteredActivities = activities.Where(x => surgeActivityCodes.Contains(x.Activity)).ToList();
        }

        var budgetAnalysis = costCategories.Select(x => new BudgetAnalysisVm
        {
            Code = x.Code,
            Description = x.Description,
            Region = options.Region,
            //Project = options.Project,
            Zone = "01",
            FromDate = options.StartDate,
            ToDate = options.EndDate,
            M01 = GetActivitySummary(filteredActivities, x, "01"),
            M02 = GetActivitySummary(filteredActivities, x, "02"),
            M03 = GetActivitySummary(filteredActivities, x, "03"),
            M04 = GetActivitySummary(filteredActivities, x, "04"),
            M05 = GetActivitySummary(filteredActivities, x, "05"),
            M06 = GetActivitySummary(filteredActivities, x, "06"),
            M07 = GetActivitySummary(filteredActivities, x, "07"),
            M08 = GetActivitySummary(filteredActivities, x, "08"),
        }).ToArray();

        foreach (var budget in budgetAnalysis)
            budget.TotalExpenditure = budget.M01 + budget.M02 + budget.M03 + budget.M04 + budget.M05 + budget.M06 +
                                      budget.M07;

        return budgetAnalysis;
    }

    public async Task<BudgetAnalysisVm[]> GetBudgetAnalysisInterventionAsync(BudgetAnalysisOptions options)
    {
        try
        {
            var interventions = await _interventionService.GetInterventionsAsync(options.Tenant);
            var activities =
                await _activityService.GetActivitiesAsync(options.Tenant, options.Region, options.ActivityType,
                    options.StartDate.ToUtcDate(), options.EndDate.ToUtcDate());

            var filteredActivities = new List<ActivityVm>(activities) { };

            if (options.isSurge)
            {
                var surgeActivities = await _surgeActivityService.GetAllAsync(bypassCache: true);
                var surgeActivityCodes = surgeActivities.Select(x => x.Code).ToArray();
                filteredActivities = activities.Where(x => surgeActivityCodes.Contains(x.Activity)).ToList();
            }

            var budgetAnalysis = interventions.Select(x => new BudgetAnalysisVm
            {
                Code = x.Code,
                Description = x.Description,
                Region = options.Region,
                Zone = "01",
                FromDate = options.StartDate,
                ToDate = options.EndDate,
                M01 = GetActivitySummary(filteredActivities, x, "01"),
                M02 = GetActivitySummary(filteredActivities, x, "02"),
                M03 = GetActivitySummary(filteredActivities, x, "03"),
                M04 = GetActivitySummary(filteredActivities, x, "04"),
                M05 = GetActivitySummary(filteredActivities, x, "05"),
                M06 = GetActivitySummary(filteredActivities, x, "06"),
                M07 = GetActivitySummary(filteredActivities, x, "07"),
                M08 = GetActivitySummary(filteredActivities, x, "08"),
            }).ToArray();

            foreach (var budget in budgetAnalysis)
                budget.TotalExpenditure = budget.M01 + budget.M02 + budget.M03 + budget.M04 + budget.M05 + budget.M06 +
                                          budget.M07;

            return budgetAnalysis;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<BudgetAnalysisVm[]> GetBudgetAnalysisSiteAsync(BudgetAnalysisOptions options)
    {
        var sites = await _siteService.GetSitesAsync(options.Tenant);

        var activities =
            await _activityService.GetActivitiesAsync(options.Tenant, options.Region, options.ActivityType,
                options.StartDate.ToUtcDate(), options.EndDate.ToUtcDate());

        var filteredActivities = new List<ActivityVm>(activities) { };

        if (options.isSurge)
        {
            var surgeActivities = await _surgeActivityService.GetAllAsync(bypassCache: true);
            var surgeActivityCodes = surgeActivities.Select(x => x.Code).ToArray();
            filteredActivities = activities.Where(x => surgeActivityCodes.Contains(x.Activity)).ToList();
        }

        var budgetAnalysis = sites.Select(x => new BudgetAnalysisVm
        {
            Code = x.Code,
            Description = x.Description,
            Region = options.Region,
            Zone = "01",
            FromDate = options.StartDate,
            ToDate = options.EndDate,
            M01 = GetActivitySummary(filteredActivities, x, "01"),
            M02 = GetActivitySummary(filteredActivities, x, "02"),
            M03 = GetActivitySummary(filteredActivities, x, "03"),
            M04 = GetActivitySummary(filteredActivities, x, "04"),
            M05 = GetActivitySummary(filteredActivities, x, "05"),
            M06 = GetActivitySummary(filteredActivities, x, "06"),
            M07 = GetActivitySummary(filteredActivities, x, "07"),
            M08 = GetActivitySummary(filteredActivities, x, "08"),
        }).ToArray();

        foreach (var budget in budgetAnalysis)
            budget.TotalExpenditure = budget.M01 + budget.M02 + budget.M03 + budget.M04 + budget.M05 + budget.M06 +
                                      budget.M07;

        return budgetAnalysis;
    }

    private static double
        GetActivitySummary(IEnumerable<ActivityVm> activities, InterventionVm intervention, string budgetCode) =>
        activities.Where(activity => activity.BudgetCode == budgetCode && activity.Intervention == intervention.Code)
            .Sum(activity => activity.Amount);

    private static double
        GetActivitySummary(IEnumerable<ActivityVm> activities, CostCategoryVm costCategory, string budgetCode) =>
        activities.Where(activity => activity.BudgetCode == budgetCode && activity.CostCategory == costCategory.Code)
            .Sum(activity => activity.Amount);

    private static double
        GetActivitySummary(IEnumerable<ActivityVm> activities, SiteVm site, string budgetCode) =>
        activities.Where(activity => activity.BudgetCode == budgetCode && activity.Site == site.Code)
            .Sum(activity => activity.Amount);
}