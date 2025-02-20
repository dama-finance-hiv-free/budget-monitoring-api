using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.API.Models;
using Dama.Fin.Application.Budgeting.Activity.Commands;
using Dama.Fin.Application.Budgeting.Activity.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class ActivitiesController : ApiControllerBase 
{
    public ActivitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ActivityQueryParameters parameters)
    {
        var currentUser = GetCurrentUser();

        var query = new ActivitiesQuery
        {
            Tenant = currentUser.Tenant,
            Region = parameters.Region,
            ActivityType = parameters.ActivityType,
            Branch = parameters.Branch
        };

        return await GetActionResult(async () =>
        {
            var activities = await _mediator.Send(query);
            return Ok(activities);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ActivityVm activity)
    {
        var currentUser = GetCurrentUser();
        activity.Tenant = currentUser.Tenant;

        return await GetActionResult(async () =>
        {
            var command = new CreateActivityCommand
            {
                Activity = activity,
                Tenant = currentUser.Tenant,
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ActivityVm activity)
    {
        var currentUser = GetCurrentUser();
        activity.Tenant = currentUser.Tenant;

        return await GetActionResult(async () =>
        {
            var command = new EditActivityCommand
            {
                Activity = activity,
                Tenant = currentUser.Tenant,
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] ActivityVm activity)
    {
        var currentUser = GetCurrentUser();
        activity.Tenant = currentUser.Tenant;

        return await GetActionResult(async () =>
        {
            var command = new DeleteActivityCommand
            {
                Activity = activity,
                Tenant = currentUser.Tenant,
                CurrentUser = currentUser.Code
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
