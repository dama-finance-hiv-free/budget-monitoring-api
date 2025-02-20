using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Queries;

public class MilestoneDashQueryHandler : RequestHandlerBase, IRequestHandler<MilestoneDashQuery, ChartVm>
{
    private readonly IWeekService _weekService;
    private readonly ICopYearService _copYearService;
    private readonly IComponentService _componentService;
    private readonly IActivityPersistence _activityPersistence;

    public MilestoneDashQueryHandler(IWeekService weekService, ICopYearService copYearService,
        IComponentService componentService, IActivityPersistence activityPersistence)
    {
        _weekService = weekService;
        _copYearService = copYearService;
        _componentService = componentService;
        _activityPersistence = activityPersistence;
    }

    public async Task<ChartVm> Handle(MilestoneDashQuery request, CancellationToken cancellationToken)
    {
        var component = await _componentService.GetAsync(request.Tenant, request.Component);
        var copYears = await _copYearService.GetCopYearsAsync(request.Tenant);
        var activeCopYear = copYears.First(x => x.Code == component.CopYear);
        var weeks = await _weekService.GetWeeksAsync(component.Code, activeCopYear.Code);

        var activities = await _activityPersistence.GetActivityJournalWithHistoryAsync(tenant: request.Tenant, region: request.Region,
            project: request.Project, startDate: component.StartDate, endDate: component.EndDate, activityType: "01");

        var chartData = new ChartVm
        {
            Categories = weeks.Select(GetWeekCategory).ToArray(),
            Series = new List<ChartSeriesVm>
            {
                new ChartSeriesVm
                {
                    Name = "Budget",
                    Data = weeks.Select(GetWeekBudget).ToArray()
                },
                new ChartSeriesVm
                {
                    Name = "Actual",
                    Data = weeks.Select(vm => GetWeekActual(vm, activities)).ToArray()
                },
                new ChartSeriesVm
                {
                    Name = "Projection",
                    Data = weeks.Select(GetWeekBudget).ToArray()
                },
                new ChartSeriesVm
                {
                    Name = "Achievement",
                    Data = weeks.Select(GetWeekBudget).ToArray()
                }
            }.ToArray()
        };

        return chartData;
    }

    private static double GetWeekBudget(WeekVm x)
    {
        return 0;
    }

    private static double GetWeekActual(WeekVm w, IEnumerable<Domain.Entity.Budgeting.Activity> activities) =>
        activities.Where(a => a.TransDate.Date >= w.WeekStartDate.Date && a.TransDate.Date <= w.WeekEndDate.Date)
            .Sum(a => a.Amount);

    private static string GetWeekCategory(WeekVm x) => $"W{x.WeekSerialAdjusted.ToString().ToTwoChar()}";
}