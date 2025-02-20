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

namespace Dama.Fin.Application.Budgeting.BudgetExecution.Queries;

public class BudgetExecutionReportQueryHandler : 
    IRequestHandler<BudgetExecutionReportQuery, ReportFileVm>
{
    private readonly IRegionPersistence _regionPersistence;
    private readonly IBudgetAnalysisReport _budgetAnalysisReport;
    private readonly IBudgetAnalysisService _budgetAnalysisService;
    private readonly IBudgetExecutionService _budgetExecutionService;
    private readonly IBudgetExecutionReport _budgetExecutionReport;

    public BudgetExecutionReportQueryHandler(
        IRegionPersistence regionPersistence,
        IBudgetAnalysisReport budgetAnalysisReport,
        IBudgetAnalysisService budgetAnalysisService,
        IBudgetExecutionService budgetExecutionService,
        IBudgetExecutionReport budgetExecutionReport)
    {
        _regionPersistence = regionPersistence;
        _budgetAnalysisReport = budgetAnalysisReport;
        _budgetAnalysisService = budgetAnalysisService;
        _budgetExecutionService = budgetExecutionService;
        _budgetExecutionReport = budgetExecutionReport;
    }

    public async Task<ReportFileVm> Handle(BudgetExecutionReportQuery request,
        CancellationToken cancellationToken)
    {
        var budgetExecution =
            await _budgetExecutionService.GetBudgetExecutionsAsync(request.Options);

        var region = await _regionPersistence.GetAsync(x => x.Code == request.Options.Region);

        var options = new BudgetAnalysisOptions()
        {
            Region = region.Description,
            StartDate = request.Options.StartDate,
            EndDate = request.Options.EndDate,
            ReportTitle = "SITE BUDGET EXECUTION"
        };

        var data = await _budgetExecutionReport.GenerateAsync(budgetExecution.ToList(), options);

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