using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;

public class OutlayAnalysisQueryHandler : RequestHandlerBase, IRequestHandler<OutlayAnalysisQuery, OutlayDashVm[]>
{
    private readonly IOutlayPersistence _outlayPersistence;
    private readonly IWeekPersistence _weekPersistence;
    private readonly IComponentPersistence _componentPersistence;

    public OutlayAnalysisQueryHandler(IOutlayPersistence outlayPersistence, IWeekPersistence weekPersistence,
        IComponentPersistence componentPersistence)
    {
        _outlayPersistence = outlayPersistence;
        _weekPersistence = weekPersistence;
        _componentPersistence = componentPersistence;
    }

    public async Task<OutlayDashVm[]> Handle(OutlayAnalysisQuery request, CancellationToken cancellationToken)
    {
        DateTime StartDate = DateTime.Now;
        DateTime EndDate = DateTime.Now;
        DateTime CurrentDate = DateTime.Now;

        var weeks = await _weekPersistence.GetAllAsync();
        var component = await _componentPersistence.GetAsync(x => x.Code == request.Component);

        if (request.DashboardType == "01") // Week to date 
        {
            var matchingWeek = weeks.Where(x => x.WeekStartDate <= CurrentDate
                                && x.WeekEndDate >= CurrentDate
                              ).First();
            StartDate = matchingWeek.WeekStartDate;
        }
        else if(request.DashboardType == "02") // Month to date
        {
            var matchingWeek = weeks.Where(x => x.WeekStartDate <= CurrentDate
                               && x.WeekEndDate >= CurrentDate).First();

            StartDate = DateTime.Parse($"01/{matchingWeek.WeekStartDate.Month}/{matchingWeek.WeekEndDate.Year}");
        }
        else if(request.DashboardType == "03") // Component to date
        {
            StartDate = component.StartDate.ToUtcDate();
        }
        else if(request.DashboardType == "04") // Year to date
        {
            StartDate = DateTime.Parse($"01/10/{DateTime.Now.Year}");
        }

        var outlays =
            await _outlayPersistence.GetOutlayAnalysisAsync(request.Tenant, request.Region, StartDate.ToUtcDate(),
                EndDate.ToUtcDate());

        const int periodDivider = 13;
        foreach (var outlay in outlays)
        {
            outlay.PeriodTarget = outlay.AnnualTarget / periodDivider;
            outlay.PeriodBudget = outlay.ComponentBudget / periodDivider;
        }
        return outlays;
    }
}