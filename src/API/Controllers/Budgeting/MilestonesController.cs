using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Milestone.Commands;
using Dama.Fin.Application.Budgeting.Milestone.Queries;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class MilestonesController : ApiControllerBase 
{
    public MilestonesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new MilestonesQuery();
            var milestones = await _mediator.Send(query);
            return Ok(milestones);
        });
    }

    [HttpPost]
    [Route("projection")]
    public async Task<IActionResult> Projection([FromBody] MilestoneVm milestone)
    {
        var currentUser = GetCurrentUser();
        milestone.Tenant = currentUser.Tenant;

        return await GetActionResult(async () =>
        {
            var command = new MilestoneProjectionCommand
            {
                Milestone = milestone
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPost]
    [Route("achievement")]
    public async Task<IActionResult> Achievement([FromBody] MilestoneVm milestone)
    {
        var currentUser = GetCurrentUser();
        milestone.Tenant = currentUser.Tenant;

        return await GetActionResult(async () =>
        {
            var command = new MilestoneAchievementCommand
            {
                Milestone = milestone
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPost]
    [Route("dashboard")]
    public async Task<IActionResult> MilestoneDashboards([FromBody] MilestoneDasboardOptions options)
    {
        return await GetActionResult(async () =>
        {
            var currentUser = GetCurrentUser();
            options.User = currentUser.Subject;
            options.Tenant = currentUser.Tenant;

            var query = new GetMilestoneDashboardsQuery()
            {
                Options = options,
            };
            var milestoneDashboards = await _mediator.Send(query);
            return Ok(milestoneDashboards);
        });
    }


    [HttpGet]
    [Route("dashboard/report")]
    [FileResultContentType("application/pdf")]
    public async Task<byte[]> MilestoneReport([FromQuery] MilestoneDasboardOptions options)
    {
        var currentUser = GetCurrentUser();
        options.User = currentUser.Subject;
        options.Tenant = currentUser.Tenant;

        var report = await _mediator.Send(new GetMilestoneReportQuery()
        {
            Options = options
        });

        return report.Data;
    }


}
