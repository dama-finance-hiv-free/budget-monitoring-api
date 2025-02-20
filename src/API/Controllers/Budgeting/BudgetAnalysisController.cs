using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.BudgetAnalysis.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class BudgetAnalysisController : ApiControllerBase 
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public BudgetAnalysisController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
    {
        _mediator = mediator;
        _webHostEnvironment = webHostEnvironment;
    }

    private readonly IMediator _mediator;

    [HttpPost]
    [Route("costCategory")]
    public async Task<IActionResult> CostCategory([FromBody] BudgetAnalysisOptions options)
    {
        return await GetActionResult(async () =>
        {
            var query = new BudgetAnalysisCostCategoryQuery
            {
                Options = options
            };
            var budgetAnalysis = await _mediator.Send(query);

            return Ok(budgetAnalysis);
        });
    }

    [HttpGet]
    [Route("costCategory/report")]
    [FileResultContentType("application/pdf")]
    public async Task<byte[]> CostCategoryReport([FromQuery] BudgetAnalysisOptions options)
    {
        var report = await _mediator.Send(new BudgetAnalysisCostCategoryReportQuery
        {
            Options = options
        });


        // return File(report.Data, report.ContentType, report.FileName);
        return report.Data;

        // return await GetPdfFileName(report, "budget-analysis-by-cost-category-report");
    }

    [HttpPost]
    [Route("intervention")]
    public async Task<IActionResult> Intervention([FromBody] BudgetAnalysisOptions options)
    {
        return await GetActionResult(async () =>
        {

            var query = new BudgetAnalysisInterventionQuery
            {
                Options = options
            };
            var budgetAnalysis = await _mediator.Send(query);

            return Ok(budgetAnalysis);
        });
    }

    [HttpGet]
    [Route("intervention/report")]
    [FileResultContentType("application/pdf")]
    public async Task<byte[]> InterventionReport([FromQuery] BudgetAnalysisOptions options)
    {
        var report = await _mediator.Send(new BudgetAnalysisInterventionReportQuery
        {
            Options = options
        });

        //return File(report.Data, report.ContentType, report.FileName);
        //return await GetPdfFileName(report, "budget-analysis-by-intervention-report");
        return report.Data;
    }

    [HttpPost]
    [Route("site")]
    public async Task<IActionResult> Site([FromBody] BudgetAnalysisOptions options)
    {
        return await GetActionResult(async () =>
        {

            var query = new BudgetAnalysisSiteQuery
            {
                Options = options
            };
            var budgetAnalysis = await _mediator.Send(query);

            return Ok(budgetAnalysis);
        });
    }

    [HttpGet]
    [Route("site/report")]
    [FileResultContentType("application/pdf")]
    public async Task<byte[]> SiteReport([FromQuery] BudgetAnalysisOptions options)
    {
        var report = await _mediator.Send(new BudgetAnalysisSiteReportQuery
        {
            Options = options
        });

        //return File(report.Data, report.ContentType, report.FileName);

        //return await GetPdfFileName(report, "budget-analysis-by-site-report");
        return report.Data;
    }
}
