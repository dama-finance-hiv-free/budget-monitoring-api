using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Report;
using Dama.Fin.Domain.Vm;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Outlay.Queries;
public class OutlayAnalysisReportQueryHandler : RequestHandlerBase,
    IRequestHandler<OutlayAnalysisReportQuery, ReportFileVm>
{
    private readonly IRegionPersistence _regionPersistence;
    private readonly IOutlayAnalysisReport _outlayAnalysisReport;
    private readonly IOutlayService _outlayService;
    private readonly IWeekPersistence _weekPersistence;
    private readonly IComponentPersistence _componentPersistence;
    private readonly IOutlayPersistence _outlayPersistence;

    public OutlayAnalysisReportQueryHandler(IRegionPersistence regionPersistence,
        IOutlayAnalysisReport outlayAnalysisReport, IOutlayService outlayService,
        IWeekPersistence weekPersistence,IComponentPersistence componentPersistence,
        IOutlayPersistence outlayPersistence)
    {
        _regionPersistence = regionPersistence;
        _outlayAnalysisReport = outlayAnalysisReport;
        _outlayService = outlayService;
        _weekPersistence = weekPersistence;
        _componentPersistence = componentPersistence;
        _outlayPersistence = outlayPersistence;
    }

    public async Task<ReportFileVm> Handle(OutlayAnalysisReportQuery request,
        CancellationToken cancellationToken)
    {
        DateTime StartDate = DateTime.Now;
        DateTime EndDate = DateTime.Now;
        DateTime CurrentDate = DateTime.Now;

        var weeks = await _weekPersistence.GetAllAsync();
        var component = await _componentPersistence.GetAsync(x => x.Code == request.Options.Component);
        var region = await _regionPersistence.GetAsync(x => x.Code == request.Options.Region);

        if (request.Options.DashboardType == "01") // Week to date 
        {
            var matchingWeek = weeks.Where(x => x.WeekStartDate <= CurrentDate
                                && x.WeekEndDate >= CurrentDate
                              ).First();
            StartDate = matchingWeek.WeekStartDate;
        }
        else if (request.Options.DashboardType == "02") // Month to date
        {
            var matchingWeek = weeks.Where(x => x.WeekStartDate <= CurrentDate
                               && x.WeekEndDate >= CurrentDate).First();

            StartDate = DateTime.Parse($"01/{matchingWeek.WeekStartDate.Month}/{matchingWeek.WeekEndDate.Year}");
        }
        else if (request.Options.DashboardType == "03") // Component to date
        {
            StartDate = component.StartDate.ToUtcDate();
        }
        else if (request.Options.DashboardType == "04") // Year to date
        {
            StartDate = DateTime.Parse($"01/10/{DateTime.Now.Year}");
        }

        var outlays =
            await _outlayPersistence.GetOutlayAnalysisAsync(request.Options.Tenant, request.Options.Region, StartDate.ToUtcDate(),
                EndDate.ToUtcDate());

        const int periodDivider = 13;
        foreach (var outlay in outlays)
        {
            outlay.PeriodTarget = outlay.AnnualTarget / periodDivider;
            outlay.PeriodBudget = outlay.ComponentBudget / periodDivider;
        }

        var options = new BudgetAnalysisOptions()
        {
            Region = region.Description,
            StartDate = StartDate,
            EndDate = EndDate,
            ReportTitle = "OUTLAY VS TARGET"
        };

        var data = await _outlayAnalysisReport.GenerateAsync(outlays.ToList(), options);

        if (data is null)
            throw new Exception("could not generate pdf report");

        var report = new ReportFileVm
        {
            ContentType = "application/pdf",
            Data = data,
            FileName = $"{Guid.NewGuid()}.pdf"
        };

        return report;
    }
}