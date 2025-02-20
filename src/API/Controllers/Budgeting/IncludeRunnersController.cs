using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.IncludeRunner.Commands;
using Dama.Fin.Application.Budgeting.IncludeRunner.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class IncludeRunnersController : ApiControllerBase 
{
    public IncludeRunnersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new IncludeRunnersQuery();
            var includeRunners = await _mediator.Send(query);
            return Ok(includeRunners);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] IncludeRunnerVm includeRunner)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateIncludeRunnerCommand
            {
                IncludeRunner = includeRunner
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] IncludeRunnerVm includeRunner)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditIncludeRunnerCommand
            {
                IncludeRunner = includeRunner
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
