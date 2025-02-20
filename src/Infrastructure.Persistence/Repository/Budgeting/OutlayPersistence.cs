using System;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Dama.Fin.Infrastructure.Persistence.Repository.Budgeting;

public class OutlayPersistence : RepositoryBase<Outlay>, IOutlayPersistence
{
    public OutlayPersistence(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
    {
    }

    public async Task<Outlay[]> GetOutlaysAsync(string tenant) => await GetManyAsync(x => x.Tenant == tenant);

    public async Task<OutlayDashVm[]> GetOutlayDashAsync(string tenant, string region)
    {
        const string sql = @"select code as outlay,
coalesce((select b.description from budgeting.budget_code b where b.code = o.budget_code),'') as budgetcode,
indicator, coalesce((select t.target from budgeting.target t where t.region = @region and t.outlay = o.code),0) as AnnualTarget,
coalesce((select sum(b.amount) from budgeting.budget b where b.component in ('02','02') and  b.region = @region and b.activity in 
(select p.code from budgeting.activity_plan p where p.intervention in 
(select oi.intervention from budgeting.outlay_intervention oi where oi.outlay = o.code) and o.type = '01')),0) as ComponentBudget,
0 as PeriodAchievement,
coalesce((select sum(a.amount) from budgeting.activity a where a.component in ('02','02') and a.region = @region and a.activity in (select p.code from budgeting.activity_plan p where p.intervention in (select oi.intervention from budgeting.outlay_intervention oi where oi.outlay = o.code) and o.type = '01')),0) +
coalesce((select sum(a.amount) from budgeting.activity_history a where a.region = @region and a.activity in (select p.code from budgeting.activity_plan p where p.intervention in (select oi.intervention from budgeting.outlay_intervention oi where oi.outlay = o.code) and o.type = '01')),0) as PeriodExpenditure
from budgeting.outlay o order by 1";

        var outlays = await Db.QueryAsync<OutlayDashVm>(sql, new { region });

        return outlays.ToArray();
    }

    public async Task<OutlayDashVm[]> GetOutlayDashAsync(string tenant, string region, string component, string copYear)
    {
        const string sql = @"select @component as component, code as outlay,
coalesce((select b.description from budgeting.budget_code b where b.code = o.budget_code),'') as budgetcode,
indicator, coalesce((select t.target from budgeting.target t where t.region = @region and cop_year = @copYear and t.outlay = o.code),0) as AnnualTarget,
coalesce((select sum(b.amount) from budgeting.budget b where b.component in (@component) and  b.region = @region and cop_year = @copYear and b.activity in 
(select p.code from budgeting.activity_plan p where p.intervention in 
(select oi.intervention from budgeting.outlay_intervention oi where oi.outlay = o.code) and o.type = '01')),0) as ComponentBudget,
0 as PeriodAchievement,
coalesce((select sum(a.amount) from budgeting.activity a 
		  where 
		  a.component in (@component) and 
		  a.region = @region and 
		  a.cop_year = @copYear and
		  a.activity in (select p.code from budgeting.activity_plan p where p.intervention in (select oi.intervention from budgeting.outlay_intervention oi where oi.outlay = o.code) and o.type = '01')),0) +
coalesce((select sum(a.amount) from budgeting.activity_history a 
		  where 
		  a.component in (@component) and
		  a.region = @region and 
		  a.cop_year = @copYear and
		  a.activity in (select p.code from budgeting.activity_plan p where p.intervention in (select oi.intervention from budgeting.outlay_intervention oi where oi.outlay = o.code) and o.type = '01')),0) as PeriodExpenditure
from budgeting.outlay o order by 2";

        var outlays = await Db.QueryAsync<OutlayDashVm>(sql, new { region, component, copYear });

        return outlays.ToArray();
    }

    public async Task<OutlayDashVm[]> GetOutlayAnalysisAsync(string tenant, string region, DateTime startDate, DateTime endDate)
    {
        const string sql = @"select code as outlay,
coalesce((select b.description from budgeting.budget_code b where b.code = o.budget_code),'') as budgetcode,
indicator, coalesce((select t.target from budgeting.target t where t.region = @region and t.outlay = o.code),0) as AnnualTarget,
coalesce((select sum(b.amount) from budgeting.budget b where b.region = @region and b.activity in 
(select p.code from budgeting.activity_plan p where p.intervention in 
(select oi.intervention from budgeting.outlay_intervention oi where oi.outlay = o.code) and o.type = '01')),0) as ComponentBudget,
0 as PeriodAchievement,
coalesce((select sum(a.amount) from budgeting.activity a where a.trans_date>=@startdate and a.trans_date<=@enddate and a.region = @region and a.activity in (select p.code from budgeting.activity_plan p where p.intervention in (select oi.intervention from budgeting.outlay_intervention oi where oi.outlay = o.code) and o.type = '01')),0) +
coalesce((select sum(a.amount) from budgeting.activity_history a where a.trans_date>=@startdate and a.trans_date<=@enddate and a.region = @region and a.activity in (select p.code from budgeting.activity_plan p where p.intervention in (select oi.intervention from budgeting.outlay_intervention oi where oi.outlay = o.code) and o.type = '01')),0) as PeriodExpenditure
from budgeting.outlay o order by 1";

        var outlays = await Db.QueryAsync<OutlayDashVm>(sql, new { region, startdate = startDate, enddate = endDate });

        return outlays.ToArray();
    }

    public async Task<OutlayDashVm[]> GetOutlayTargetAsync(string tenant, string region)
    {
        const string sql = @"select code as outlay,
                    coalesce((select b.description from budgeting.budget_code b where b.code = o.budget_code),'') as budgetcode,
                    indicator, coalesce((select t.target from budgeting.target t where t.region = @region and t.outlay = o.code),0) as AnnualTarget,
                    coalesce((select sum(b.amount) from budgeting.budget b where b.region = @region and b.activity in 
                    (select p.code from budgeting.activity_plan p where p.intervention in 
                    (select oi.intervention from budgeting.outlay_intervention oi where oi.outlay = o.code) and o.type = '01')),0) as ComponentBudget,
                    0 as PeriodAchievement,
                    coalesce((select sum(a.amount) from budgeting.activity a where a.region = @region 
                    and a.activity in (select p.code from budgeting.activity_plan p where p.intervention in 
                    (select oi.intervention from budgeting.outlay_intervention oi where oi.outlay = o.code) and o.type = '01')),0) as PeriodExpenditure
                    from budgeting.outlay o order by 1";

        var outlays = await Db.QueryAsync<OutlayDashVm>(sql, new { region });

        return outlays.ToArray();
    }

    protected override async Task<Outlay> ItemToGetAsync(string tenant, string outlay) =>
        await GetFirstOrDefaultAsync(x => x.Code == outlay);

    protected override async Task<Outlay> ItemToGetAsync(Outlay outlay) =>
        await GetFirstOrDefaultAsync(x => x.Code == outlay.Code);

    public async Task<OutlayCostCategoryDashboardVm> GetOutlayCostCategory(OutlayOption options)
    {
        var startDate = options.StartDate;
        var endDate = options.EndDate;

        var monthStartDate = options.StartDate.ToMonthEndDate();
        var monthEndDate = options.StartDate.ToMonthEndDate();

        var component = await Context.ComponentSet.FirstOrDefaultAsync(x =>
            x.CopYear == options.CopYear && x.Project == "01" && x.Code == options.Component);

        if (component == null)
            return null;

        var componentStartDate = component.StartDate;
        var componentEndDate = component.EndDate;

        var parameters = new
        {
            options.Tenant,
            Project = "01",
            options.CopYear,
            TranCode = "01",
            ReportType = "01",
            options.Region,
            options.User,
            StartDate = startDate,
            EndDate = endDate,
            MonthStartDate = monthStartDate,
            MonthEndDate = monthEndDate,
            ComponentStartDate = componentStartDate,
            ComponentEndDate = componentEndDate
        };

        //var outlayInterventions = await Db.CustomQueryAsync<OutlayCostCategoryVm>("[dbo].[OutlayCostCategory]", parameters,
        //        commandType: CommandType.StoredProcedure);

        return new OutlayCostCategoryDashboardVm
        {
            //OutlayCostCategory = outlayInterventions.ToArray(),
            WeekStartDate = startDate.ToDateWithoutTime(),
            WeekEndDate = endDate.ToDateWithoutTime(),
            MonthStartDate = monthStartDate.ToDateWithoutTime(),
            MonthEndDate = monthEndDate.ToDateWithoutTime(),
            ComponentStartDate = componentStartDate.ToDateWithoutTime(),
            ComponentEndDate = componentEndDate.ToDateWithoutTime(),
        };
    }
}