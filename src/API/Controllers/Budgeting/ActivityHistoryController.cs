using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Activity.Commands;
using Dama.Fin.Application.Budgeting.Activity.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class ActivityHistoryController : ApiControllerBase 
{
    public ActivityHistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ActivitySummaryParameters parameters)
    {
        var currentUser = GetCurrentUser();
        parameters.Tenant = currentUser.Tenant;

        var query = new ActivitySummaryQuery
        {
            Options = parameters
        };

        return await GetActionResult(async () =>
        {
            var activities = await _mediator.Send(query);
            return Ok(activities);
        });
    }


    [HttpGet]
    [Route("{batchCode}")]
    public async Task<IActionResult> GetBatchLines(string batchCode)
    {
        var currentUser = GetCurrentUser();
        var query = new ActivityHistoryBatchQuery
        {
            BatchCode = batchCode
        };

        return await GetActionResult(async () =>
        {
            var activities = await _mediator.Send(query);
            return Ok(activities);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ActivityVm activityHistory)
    {
        var currentUser = GetCurrentUser();
        activityHistory.Tenant = currentUser.Tenant;

        return await GetActionResult(async () =>
        {
            var command = new EditActivityHistoryCommand
            {
                ActivityHistory = activityHistory,
                Tenant = currentUser.Tenant,
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }
}
