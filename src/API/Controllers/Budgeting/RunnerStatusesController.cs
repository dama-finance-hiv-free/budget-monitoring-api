using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.RunnerStatus.Commands;
using Dama.Fin.Application.Budgeting.RunnerStatus.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class RunnerStatusesController : ApiControllerBase 
{
    public RunnerStatusesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new RunnersStatusQuery();
            var runnersStatus = await _mediator.Send(query);
            return Ok(runnersStatus);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RunnerStatusVm runnerStatus)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateRunnerStatusCommand
            {
                RunnerStatus = runnerStatus
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RunnerStatusVm runnerStatus)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRunnerStatusCommand
            {
                RunnerStatus = runnerStatus
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
