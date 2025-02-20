using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.RunnerComponent.Commands;
using Dama.Fin.Application.Budgeting.RunnerComponent.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class RunnerComponentsController : ApiControllerBase 
{
    public RunnerComponentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new RunnerComponentsQuery();
            var runnerComponents = await _mediator.Send(query);
            return Ok(runnerComponents);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RunnerComponentVm runnerComponent)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateRunnerComponentCommand
            {
                RunnerComponent = runnerComponent
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RunnerComponentVm runnerComponent)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRunnerComponentCommand
            {
                RunnerComponent = runnerComponent
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
