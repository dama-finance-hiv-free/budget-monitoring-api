using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.RunnerPeriodComponent.Commands;
using Dama.Fin.Application.Budgeting.RunnerPeriodComponent.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class RunnerPeriodComponentsController : ApiControllerBase 
{
    public RunnerPeriodComponentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new RunnerPeriodComponentsQuery();
            var runnerPeriodComponents = await _mediator.Send(query);
            return Ok(runnerPeriodComponents);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RunnerPeriodComponentVm runnerPeriodComponent)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateRunnerPeriodComponentCommand
            {
                RunnerPeriodComponent = runnerPeriodComponent
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RunnerPeriodComponentVm runnerPeriodComponent)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRunnerPeriodComponentCommand
            {
                RunnerPeriodComponent = runnerPeriodComponent
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}
