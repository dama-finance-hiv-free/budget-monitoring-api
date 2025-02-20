using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Dapper;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class BudgetPersistence : RepositoryBase<Budget>, IBudgetPersistence
{
    private readonly IRunnerPersistence _runnerPersistence;

    public BudgetPersistence(IDatabaseFactory databaseFactory, IRunnerPersistence runnerPersistence) : base(
        databaseFactory)
    {
        _runnerPersistence = runnerPersistence;
    }

    public override async Task<RepositoryActionResult<Budget>> AddAsync(Budget entity)
    {
        await using var tx = await Context.Database.BeginTransactionAsync();
        try
        {
            var lastBudget = DbSet.OrderByDescending(x => x.CopYear).ToArray().FirstOrDefault();
            var serial = lastBudget == null
                ? "1".ToTwoChar()
                : (lastBudget.CopYear.ToNumValue() + 1)
                .ToNumValue().ToString(CultureInfo.InvariantCulture).ToTwoChar();
            entity.CopYear = serial;

            DbSet.Add(entity);
            var result = await SaveChangesAsync();
            if (result == 0)
            {
                return new RepositoryActionResult<Budget>(entity, RepositoryActionStatus.NothingModified);
            }

            await tx.CommitAsync();
            return new RepositoryActionResult<Budget>(entity, RepositoryActionStatus.Created);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return new RepositoryActionResult<Budget>(null, RepositoryActionStatus.Error, ex);
        }
    }

    public async Task<BudgetSummaryBatchVm> GetBudgetSummaryBatchAsync(string project, string component)
    {
        var (startDate, endDate) = await GetDateRangeAsync("01", project, "month");

        var budgetCodes = await GetBudgetSummaryAsync(project, component, "", startDate, endDate, GetBudgetSummaryBudgetCodeQuery());
        var interventions = await GetBudgetSummaryAsync(project, component, "", startDate, endDate, GetBudgetSummaryInterventionQuery());
        var costCategories = await GetBudgetSummaryAsync(project, component, "", startDate, endDate, GetBudgetSummaryCostCategoryQuery());

        var budgetSummary = new BudgetSummaryBatchVm
        {
            BudgetCodes = budgetCodes,
            Interventions = interventions,
			CostCategories = costCategories
        };

        return budgetSummary;
    }

    public async Task<BudgetDashboardVm> GetBudgetDashboardAsync(string project, string component, string region,
        string period)
    {
        var (startDate, endDate) = await GetDateRangeAsync(region, project, period);
        
        var annualBudgets = await GetBudgetSummaryAsync(project, "00", region, startDate, startDate, GetBudgetSummaryBudgetCodeQuery());
        var componentBudgets = await GetBudgetSummaryAsync(project, component, region, startDate, endDate, GetBudgetSummaryBudgetCodeQuery());
        var regionExpenditures = await GetBudgetSummaryAsync(project, component, region, startDate, endDate, GetExpenditureRegionSummaryBudgetCodeQuery());
        var totalExpenditures = await GetBudgetSummaryAsync(project, component, region, startDate, endDate, GetExpenditureTotalSummaryBudgetCodeQuery());
        var interventions = await GetBudgetSummaryAsync(project, component, region, startDate, endDate, GetBudgetSummaryInterventionQuery());
        var costCategories = await GetBudgetSummaryAsync(project, component, region, startDate, endDate, GetBudgetSummaryCostCategoryQuery());

        var budgetSummary = new BudgetDashboardVm
        {
            AnnualBudgets = await UpdateBudgetSummaryAsync(annualBudgets),
            ComponentBudgets = await UpdateBudgetSummaryAsync(componentBudgets),
            RegionExpenditures = await UpdateBudgetSummaryAsync(regionExpenditures),
            TotalExpenditures = await UpdateBudgetSummaryAsync(totalExpenditures),
			Interventions = interventions,
			CostCategories = costCategories
        };

        return budgetSummary;
    }

    public async Task<Budget[]> GetBudgetsAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    protected override async Task<Budget> ItemToGetAsync(string tenant, string budget) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == budget);

    protected override async Task<Budget> ItemToGetAsync(Budget budget) =>
        await GetFirstOrDefaultAsync(x => x.CopYear == budget.CopYear);

    private async Task<BudgetSummaryVm[]> GetBudgetSummaryAsync(string project, string component, string region,
        DateTime startDate, DateTime endDate, string querySql)
    {
        var parameters = new
        {
            project,
            component,
            region,
            startDate,
            endDate
        };
        var budgetAmounts = await Db.QueryAsync<BudgetSummaryVm>(querySql, parameters);
        return budgetAmounts.ToArray();
    }

    private async Task<BudgetSummaryVm[]> UpdateBudgetSummaryAsync(BudgetSummaryVm[] amounts)
    {
        var budgetDictionary = amounts.ToDictionary(x => x.Code, x => x);
        var budgetCodeItems = await GetBudgetCodeItemsAsync();

        return budgetCodeItems.Select(x => new BudgetSummaryVm
        {
            Code = x.Code,
            Description = x.Description,
            AmountUsd = budgetDictionary.ContainsKey(x.Code) ? budgetDictionary[x.Code].AmountUsd : 0,
            AmountCfa = budgetDictionary.ContainsKey(x.Code) ? budgetDictionary[x.Code].AmountCfa : 0
        }).ToArray();
    }

    private async Task<BudgetSummaryVm[]> GetBudgetCodeItemsAsync()
    {
        var querySql = @"
SELECT bc.code,bc.description FROM budgeting.budget_code bc 
WHERE bc.code IN (SELECT DISTINCT budget_code FROM budgeting.intervention) 
ORDER BY bc.code;
";
        var budgetCodeItems = await Db.QueryAsync<BudgetSummaryVm>(querySql);

        return budgetCodeItems.ToArray();
    }

    private async Task<(DateTime StartDate, DateTime EndDate)> GetDateRangeAsync(string region, string project,
        string period)
    {
        var startDate = new DateTime(2025, 1, 1);
        var endDate = new DateTime(2025, 1, 31);
        var currentRunner = await _runnerPersistence.GetActiveRunnerAsync(region, project);
        if (currentRunner == null)
        {
            return (startDate, endDate);
        }

        switch (period)
        {
            case "week":
                startDate = currentRunner.StartDate.ToUtcDate();
                endDate = currentRunner.EndDate.ToUtcDate();
                break;
            case "month":
                startDate = new DateTime(currentRunner.EndDate.Year, currentRunner.EndDate.Month, 1).ToUtcDate();
                endDate = startDate.ToMonthEndDate().ToUtcDate();
                break;
            case "component":
                startDate = GetComponentStartDate(currentRunner).ToUtcDate();
                endDate = startDate.AddMonths(3).ToMonthEndDate().ToUtcDate();
                break;
        }

        return (startDate, endDate);
    }

    private static DateTime GetComponentStartDate(RunnerBase currentRunner)
    {
        var year = currentRunner.StartDate.Year;
        var month = currentRunner.StartDate.Month;

        // Calculate the start month for the quarter
        var startMonth = (month - 1) / 3 * 3 + 1;

        return new DateTime(year, startMonth, 1);
    }

    private static string GetBudgetSummaryInterventionQuery()
    {
        return @"
WITH activity_plan_cte(code,intervention,budget_code) AS (
	SELECT 
		p.code, 
		p.intervention, 
		i.budget_code 
	FROM 
		budgeting.activity_plan p
	INNER JOIN 
		budgeting.intervention i ON i.code = p.intervention
	WHERE 
		p.project = @project
),
intervention_cte(code,description) as (
	SELECT i.code,i.description FROM budgeting.intervention i
),
budget_summary_cte(budget_code,amount) AS (
	SELECT 
		p.intervention,
		ROUND(SUM(b.amount::numeric), 0) AS total_amount
	FROM 
		activity_plan_cte p
	INNER JOIN 
		budgeting.budget b ON p.code = b.activity
	WHERE 
		b.component = @component and b.project = @project
	GROUP BY 
		p.intervention
)
SELECT 
	bs.budget_code as code,
	COALESCE((SELECT i.description FROM intervention_cte i WHERE i.code = bs.budget_code),'') AS description,
	bs.amount AS amountusd,
	bs.amount*600 AS amountcfa
FROM budget_summary_cte bs
ORDER BY 1;
";
    }

    private static string GetBudgetSummaryBudgetCodeQuery()
    {
        return @"
WITH activity_plan_cte(code,intervention,budget_code) AS (
	SELECT 
		p.code, 
		p.intervention, 
		i.budget_code 
	FROM 
		budgeting.activity_plan p
	INNER JOIN 
		budgeting.intervention i ON i.code = p.intervention
	WHERE 
		p.project = @project
),
budget_code_cte(code,description) as (
	SELECT bc.code,bc.description FROM budgeting.budget_code bc
),
budget_summary_cte(budget_code,amount) AS (
	SELECT 
		p.budget_code,
		ROUND(SUM(b.amount::numeric), 0) AS total_amount
	FROM 
		activity_plan_cte p
	INNER JOIN 
		budgeting.budget b ON p.code = b.activity
	WHERE 
		b.component = @component and b.project = @project
	GROUP BY 
		p.budget_code
)
SELECT 
	bs.budget_code as code,
	COALESCE((SELECT bc.description FROM budget_code_cte bc WHERE bc.code = bs.budget_code),'') AS description,
	bs.amount AS amountusd,
	bs.amount*600 AS amountcfa
FROM budget_summary_cte bs
ORDER BY 1;
";
    }

    private static string GetBudgetSummaryCostCategoryQuery()
    {
        return @"
WITH activity_plan_cte(code,intervention,cost_category,budget_code) AS (
	SELECT 
		p.code, 
		p.intervention, 
	    p.cost_category,
		i.budget_code 
	FROM 
		budgeting.activity_plan p
	INNER JOIN 
		budgeting.intervention i ON i.code = p.intervention
	WHERE 
		p.project = @project
),
budget_code_cte(code,description) as (
	SELECT bc.code,bc.description FROM budgeting.cost_category bc
),
budget_summary_cte(cost_category,amount) AS (
	SELECT 
		p.cost_category,
		ROUND(SUM(b.amount::numeric), 0) AS total_amount
	FROM 
		activity_plan_cte p
	INNER JOIN 
		budgeting.budget b ON p.code = b.activity
	WHERE 
		b.component = @component and b.project = @project
	GROUP BY 
		p.cost_category
)
SELECT 
	bs.cost_category as code,
	COALESCE((SELECT bc.description FROM budget_code_cte bc WHERE bc.code = bs.cost_category),'') AS description,
	bs.amount AS amountusd,
	bs.amount*600 AS amountcfa
FROM budget_summary_cte bs
ORDER BY 1;
";
    }

    private static string GetExpenditureTotalSummaryBudgetCodeQuery()
    {
        return @"
WITH activity_plan_cte(code,intervention,budget_code) AS (
	SELECT 
		p.code, 
		p.intervention, 
		i.budget_code 
	FROM 
		budgeting.activity_plan p
	INNER JOIN 
		budgeting.intervention i ON i.code = p.intervention
	WHERE 
		p.project = @project
),
budget_code_cte(code,description) as (
	SELECT bc.code,bc.description FROM budgeting.budget_code bc
),
activity_cte(activity,project,region,amount) as (
	SELECT a.activity,a.project,a.region,a.amount FROM budgeting.activity a WHERE a.trans_date BETWEEN @StartDate AND @EndDate
	UNION ALL
	SELECT a.activity,a.project,a.region,a.amount FROM budgeting.activity_history a WHERE a.trans_date BETWEEN @StartDate AND @EndDate
),
budget_summary_cte(budget_code,amount) AS (
	SELECT 
		p.budget_code,
		ROUND(SUM(b.amount::numeric), 0) AS total_amount
	FROM 
		activity_plan_cte p
	INNER JOIN 
		activity_cte b ON p.code = b.activity
	WHERE 
		b.project = @project
	GROUP BY 
		p.budget_code
)
SELECT 
	bs.budget_code as code,
	COALESCE((SELECT bc.description FROM budget_code_cte bc WHERE bc.code = bs.budget_code),'') AS description,
	ROUND(bs.amount/600::numeric, 0) AS amountusd,
	bs.amount AS amountcfa
FROM budget_summary_cte bs
ORDER BY 1;
";
    }

    private static string GetExpenditureRegionSummaryBudgetCodeQuery()
    {
        return @"
WITH activity_plan_cte(code,intervention,budget_code) AS (
	SELECT 
		p.code, 
		p.intervention, 
		i.budget_code 
	FROM 
		budgeting.activity_plan p
	INNER JOIN 
		budgeting.intervention i ON i.code = p.intervention
	WHERE 
		p.project = @project
),
budget_code_cte(code,description) as (
	SELECT bc.code,bc.description FROM budgeting.budget_code bc
),
activity_cte(activity,project,region,amount) as (
	SELECT a.activity,a.project,a.region,a.amount FROM budgeting.activity a WHERE a.trans_date BETWEEN @StartDate AND @EndDate
	UNION ALL
	SELECT a.activity,a.project,a.region,a.amount FROM budgeting.activity_history a WHERE a.trans_date BETWEEN @StartDate AND @EndDate
),
budget_summary_cte(budget_code,amount) AS (
	SELECT 
		p.budget_code,
		ROUND(SUM(b.amount::numeric), 0) AS total_amount
	FROM 
		activity_plan_cte p
	INNER JOIN 
		activity_cte b ON p.code = b.activity
	WHERE 
		b.project = @project and b.region = @region
	GROUP BY 
		p.budget_code
)
SELECT 
	bs.budget_code as code,
	COALESCE((SELECT bc.description FROM budget_code_cte bc WHERE bc.code = bs.budget_code),'') AS description,
	ROUND(bs.amount/600::numeric, 0) AS amountusd,
	bs.amount AS amountcfa
FROM budget_summary_cte bs
ORDER BY 1;
";
    }
}

