using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.API.Models;
using Dama.Fin.Application.Budgeting.RunnerPeriod.Commands;
using Dama.Fin.Application.Budgeting.RunnerPeriod.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class RunnerPeriodsController : ApiControllerBase 
{
    public RunnerPeriodsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get ()
    {
        var currentUser = GetCurrentUser();

        return await GetActionResult(async () =>
        {
            var query = new RunnerPeriodsQuery
            {
                Tenant = currentUser.Tenant
            };

            var runnerPeriods = await _mediator.Send(query);
            return Ok(runnerPeriods);
        });
    }

    [HttpGet]
    [Route("historyCodes")]
    public async Task<IActionResult> Get([FromQuery] RunnerPeriodQueryParameters parameters)
    {
        var currentUser = GetCurrentUser();

        return await GetActionResult(async () =>
        {
            var query = new RunnerPeriodHistoryCodesQuery
            {
                Tenant = currentUser.Tenant,
                Project = parameters.Project,
                CopYear = parameters.CopYear,
                Region = parameters.Region,
            };

            var runnerPeriods = await _mediator.Send(query);
            return Ok(runnerPeriods);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RunnerPeriodVm runnerPeriod)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateRunnerPeriodCommand
            {
                RunnerPeriod = runnerPeriod
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RunnerPeriodVm runnerPeriod)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRunnerPeriodCommand
            {
                RunnerPeriod = runnerPeriod
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPost]
    [Route("activate")]
    public async Task<IActionResult> Activate([FromBody] RunnerPeriodVm runnerPeriod)
    {
        return await GetActionResult(async () =>
        {
            var milestoneCommand = new ActivateRunnerPeriodCommand
            {
                RunnerPeriod = runnerPeriod
            };
            var commandResponse = await _mediator.Send(milestoneCommand);
            return Ok(commandResponse);
        });
    }

    [HttpPost]
    [Route("archive")]
    public async Task<IActionResult> Archive([FromBody] RunnerPeriodVm runnerPeriod)
    {
        return await GetActionResult(async () =>
        {
            var milestoneCommand = new ArchiveRunnerPeriodCommand
            {
                RunnerPeriod = runnerPeriod
            };
            var commandResponse = await _mediator.Send(milestoneCommand);
            return Ok(commandResponse);
        });
    }

}
