using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.API.Models;
using Dama.Fin.Application.Budgeting.Outlay.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class OutlayAnalysisController : ApiControllerBase 
{
    public OutlayAnalysisController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] OutlayAnalysisQueryParameters parameters)
    {
        var currentUser = GetCurrentUser();

        return await GetActionResult(async () =>
        {
            var query = new OutlayAnalysisQuery
            {
                Tenant = currentUser.Tenant,
                Region = parameters.Region,
                DashboardType = parameters.DashboardType,
                Component = parameters.Component
            };
            var outlayDash = await _mediator.Send(query);
            return Ok(outlayDash);
        });
    }


    [HttpGet]
    [Route("report")]
    [FileResultContentType("application/pdf")]
    public async Task<byte[]> OutlayDashReport([FromQuery] OutlayAnalysisOptions options)
    {
        var report = await _mediator.Send(new OutlayAnalysisReportQuery
        {
            Options = options
        });


         //return File(report.Data, report.ContentType, report.FileName);
        return report.Data;


        // return await GetPdfFileName(report, "budget-analysis-by-cost-category-report");
    }
}
