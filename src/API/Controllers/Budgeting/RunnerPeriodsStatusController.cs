using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.RunnerPeriodStatus.Commands;
using Dama.Fin.Application.Budgeting.RunnerPeriodStatus.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class RunnerPeriodsStatusController : ApiControllerBase 
{
    public RunnerPeriodsStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new RunnerPeriodsStatusQuery();
            var runnerPeriodsStatus = await _mediator.Send(query);
            return Ok(runnerPeriodsStatus);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RunnerPeriodStatusVm runnerPeriodStatus)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateRunnerPeriodStatusCommand
            {
                RunnerPeriodStatus = runnerPeriodStatus
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RunnerPeriodStatusVm runnerPeriodStatus)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRunnerPeriodStatusCommand
            {
                RunnerPeriodStatus = runnerPeriodStatus
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
