using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Contracts.Service.Report;
using Dama.Fin.Domain.Vm;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetAnalysis.Queries;
public class BudgetAnalysisSiteReportQueryHandler : 
    IRequestHandler<BudgetAnalysisSiteReportQuery, ReportFileVm>
{
    private readonly IRegionPersistence _regionPersistence;
    private readonly IBudgetAnalysisReport _budgetAnalysisReport;
    private readonly IBudgetAnalysisService _budgetAnalysisService;

    public BudgetAnalysisSiteReportQueryHandler(IRegionPersistence regionPersistence,
        IBudgetAnalysisReport budgetAnalysisReport, IBudgetAnalysisService budgetAnalysisService)
    {
        _regionPersistence = regionPersistence;
        _budgetAnalysisReport = budgetAnalysisReport;
        _budgetAnalysisService = budgetAnalysisService;
    }

    public async Task<ReportFileVm> Handle(BudgetAnalysisSiteReportQuery request,
        CancellationToken cancellationToken)
    {
        var budgetAnalysis =
            await _budgetAnalysisService.GetBudgetAnalysisSiteAsync(request.Options);

        var region = await _regionPersistence.GetAsync(x => x.Code == request.Options.Region);

        var options = new BudgetAnalysisOptions()
        {
            Region = region.Description,
            StartDate = request.Options.StartDate,
            EndDate = request.Options.EndDate,
            ReportTitle = "BUDGET ANALYSIS BY SITE"
        };

        var data = await _budgetAnalysisReport.GenerateAsync(budgetAnalysis.ToList(), options);

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