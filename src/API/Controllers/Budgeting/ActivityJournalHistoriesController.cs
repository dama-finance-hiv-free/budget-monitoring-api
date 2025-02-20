using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.API.Models;
using Dama.Fin.Application.Budgeting.Activity.Commands;
using Dama.Fin.Application.Budgeting.Activity.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class ActivityJournalHistoriesController : ApiControllerBase 
{
    public ActivityJournalHistoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new ActivitiesHistoryQuery();
            var activityJournalHistories = await _mediator.Send(query);
            return Ok(activityJournalHistories);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ActivityVm activity)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateActivityHistoryCommand
            {
                ActivityHistory = activity
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ActivityVm activity)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditActivityHistoryCommand
            {
                ActivityHistory = activity
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpGet]
    [Route("Summary")]
    public async Task<IActionResult> Summary([FromQuery] ActivityHistorySummaryParameters parameters)
    {
        return await GetActionResult(async () =>
        {
            var vm = new ActivityHistoryOptionsVm
            {
                Tenant = parameters.Tenant,
                Component = parameters.Component,
                CopYear = parameters.CopYear,
                Runner = parameters.Runner,
                Project = parameters.Project
            };

            var query = new ActivitiesHistorySummaryQuery
            {
                Options = vm
            };
            var response = await _mediator.Send(query);

            return Ok(response);
        });
    }

}
