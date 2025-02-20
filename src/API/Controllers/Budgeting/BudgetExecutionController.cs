using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.BudgetExecution.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class BudgetExecutionController : ApiControllerBase 
{
    public BudgetExecutionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpPost]
    public async Task<IActionResult> CostCategory([FromBody] BudgetAnalysisOptions options)
    {
        return await GetActionResult(async () =>
        {
            var query = new BudgetExecutionQuery
            {
                Options = options
            };
            var budgetExecutions = await _mediator.Send(query);

            return Ok(budgetExecutions);
        });
    }

    [HttpGet]
    [FileResultContentType("application/pdf")]
    public async Task<byte[]> Report([FromQuery] BudgetAnalysisOptions options)
    {
        var report = await _mediator.Send(new BudgetExecutionReportQuery
        {
            Options = options
        });


        // return File(report.Data, report.ContentType, report.FileName);
        return report.Data;

        // return await GetPdfFileName(report, "budget-analysis-by-cost-category-report");
    }
}
