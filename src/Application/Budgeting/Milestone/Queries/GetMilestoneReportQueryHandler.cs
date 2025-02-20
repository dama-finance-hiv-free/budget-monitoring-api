using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Report;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Queries;
public class GetMilestoneReportQueryHandler :
    IRequestHandler<GetMilestoneReportQuery, ReportFileVm>
{
    private readonly IMilestoneReport _milestoneReport;
    private readonly IMilestonePersistence _milestonePersistence;
    private readonly ISitePersistence _sitePersistence;
    private readonly IRunnerHistoryPersistence _runnerHistoryPersistence;
    private readonly IRegionPersistence _regionPersistence;
    private readonly IMapper _mapper;

    public GetMilestoneReportQueryHandler(IMapper mapper, IMilestoneReport milestoneReport, IRegionPersistence regionPersistence, IRunnerHistoryPersistence runnerHistoryPersistence, ISitePersistence sitePersistence , IMilestonePersistence milestonePersistence)
    {
        _milestoneReport = milestoneReport;
        _milestonePersistence = milestonePersistence;
        _sitePersistence = sitePersistence;
        _runnerHistoryPersistence = runnerHistoryPersistence;
        _regionPersistence = regionPersistence;
        _mapper = mapper;
    }

    public async Task<ReportFileVm> Handle(GetMilestoneReportQuery request,
        CancellationToken cancellationToken)
    {
        var milestonesDashboard =
            await _milestonePersistence.GetMilestoneDashboardBySite(request.Options);

        var region = await _regionPersistence.GetAsync(x => x.Code == request.Options.Region);
        var site = await _sitePersistence.GetAsync(x => x.Code == request.Options.Site);
        var runner = await _runnerHistoryPersistence.GetAsync(x => x.Code == request.Options.Runner);

        var options = new MilestoneDasboardOptions()
        {
            Site = site.Description ?? "",
            Runner = request.Options.Runner ?? "",
            User = request.Options.User ?? "",
            Tenant = request.Options.Tenant ?? "",
            ReportTitle = "MILESTONE REPORT" ?? "",
            StartDate = runner.StartDate,
            EndDate = runner.EndDate,
            Region = region.Description ?? "",
        };


        List<MilestoneDashboardVm> milestoneDashboardVms = milestonesDashboard.ToList();
        var data = await _milestoneReport.GenerateAsync(milestoneDashboardVms, options);

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