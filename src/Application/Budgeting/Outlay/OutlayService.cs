using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Contracts;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using Microsoft.Extensions.Caching.Distributed;

namespace Dama.Fin.Application.Budgeting.Outlay;

public class OutlayService : ServiceBase<Domain.Entity.Budgeting.Outlay, OutlayVm>, IOutlayService
{
    private readonly IOutlayPersistence _outlayPersistence;
    private readonly IMapper _mapper;

    public OutlayService(IDataPersistence<Domain.Entity.Budgeting.Outlay> persistence, IMapper mapper,
        IDistributedCache cache, IOutlayPersistence outlayPersistence) : base(persistence, mapper, cache)
    {
        _outlayPersistence = outlayPersistence;
        _mapper = mapper;
    }

    public async Task<OutlayVm[]> GetOutlaysAsync(string tenant)
    {
        var outlays = await _outlayPersistence.GetOutlaysAsync(tenant);
        return  _mapper.Map<OutlayVm[]>(outlays);
    }

    public async Task<OutlayCostCategoryDashboardVm> GetOutlayCostCategory(OutlayOption options)
    {
        var outlayCostCategory = await _outlayPersistence.GetOutlayCostCategory(options);

        var outlayInterventionsList = outlayCostCategory.OutlayCostCategory.ToList();

        foreach (var outlayIntervention in outlayInterventionsList)
        {
            CalculatePercentage(outlayIntervention);
        }

        var outlayCostCategoryTotals = new OutlayCostCategoryVm
        {
            Tenant = "101",
            Code = "",
            User = options.User,
            Period = "",
            CostCategoryName = "TOTAL",
            BudgetCode = "",
            BudgetCodeDescription = "",
            BudgetAmount = outlayInterventionsList.Sum(x => x.BudgetAmount),
            ComponentExpenditure = outlayInterventionsList.Sum(x => x.ComponentExpenditure),
            ComponentBudget = outlayInterventionsList.Sum(x => x.ComponentBudget),
            ComponentVariance = outlayInterventionsList.Sum(x => x.ComponentVariance),
            ComponentPercentage = outlayInterventionsList.Sum(x => x.ComponentPercentage),
            MonthExpenditure = outlayInterventionsList.Sum(x => x.MonthExpenditure),
            MonthBudget = outlayInterventionsList.Sum(x => x.MonthBudget),
            MonthVariance = outlayInterventionsList.Sum(x => x.MonthVariance),
            MonthPercentage = outlayInterventionsList.Sum(x => x.MonthPercentage),
            WeekExpenditure = outlayInterventionsList.Sum(x => x.WeekExpenditure),
            WeekBudget = outlayInterventionsList.Sum(x => x.WeekBudget),
            WeekVariance = outlayInterventionsList.Sum(x => x.WeekVariance),
            WeekPercentage = outlayInterventionsList.Sum(x => x.WeekPercentage),
        };

        CalculatePercentage(outlayCostCategoryTotals);

        outlayInterventionsList.Add(outlayCostCategoryTotals);

        outlayCostCategory.OutlayCostCategory = outlayInterventionsList.ToArray();

        return outlayCostCategory;
    }

    private static void CalculatePercentage(OutlayBaseVm outlay)
    {
        outlay.WeekBudget = (float)Math.Round(outlay.BudgetAmount / 13, 0);
        outlay.WeekVariance =
            (float)Math.Round(outlay.WeekBudget - outlay.WeekExpenditure, 0);

        if (outlay.WeekBudget > 0)
        {
            outlay.WeekPercentage =
                (float)Math.Round(outlay.WeekExpenditure / outlay.WeekBudget, 2);
        }


        outlay.MonthBudget = (float)Math.Round(outlay.BudgetAmount / 3, 0);
        outlay.MonthVariance =
            (float)Math.Round(outlay.MonthBudget - outlay.MonthExpenditure, 0);

        if (outlay.MonthBudget > 0)
        {
            outlay.MonthPercentage =
                (float)Math.Round(outlay.MonthExpenditure / outlay.MonthBudget, 2);
        }

        outlay.ComponentBudget = (float)Math.Round(outlay.BudgetAmount, 0);
        outlay.ComponentVariance =
            (float)Math.Round(outlay.ComponentBudget - outlay.ComponentExpenditure, 0);

        if (outlay.ComponentBudget > 0)
        {
            outlay.ComponentPercentage =
                (float)Math.Round(outlay.ComponentExpenditure / outlay.ComponentBudget, 2);
        }
    }
}