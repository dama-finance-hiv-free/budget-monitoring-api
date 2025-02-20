using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.API.Models;
using Dama.Fin.Application.Budgeting.ActivityPlan.Commands;
using Dama.Fin.Application.Budgeting.ActivityPlan.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class ActivityPlansController : ApiControllerBase 
{
    public ActivityPlansController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;


    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]ActivityPlanParameters parameters)
    {
        var currentUser = GetCurrentUser();

        return await GetActionResult(async () =>
        {
            var query = new ActivityPlansQuery
            {
                Tenant = currentUser.Tenant,
                CopYear = parameters.CopYear,
                Component = parameters.Component,
                Project = parameters.Project
            };
            var activityPlans = await _mediator.Send(query);
            return Ok(activityPlans);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ActivityPlanVm activityPlan)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateActivityPlanCommand
            {
                ActivityPlan = activityPlan
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ActivityPlanVm activityPlan)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditActivityPlanCommand
            {
                ActivityPlan = activityPlan
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpGet]
    [Route("exportpdf")]
    [FileResultContentType("application/pdf")]
    public async Task<FileResult> ExportEventsToPdf()
    {
        var currentUser = GetCurrentUser();

        var query = new ActivityPlanReportQuery
        {
            Tenant = currentUser.Tenant
        };

        var fileDto = await _mediator.Send(query);
        return File(fileDto.Data, fileDto.ContentType, fileDto.FileName);
    }
}
