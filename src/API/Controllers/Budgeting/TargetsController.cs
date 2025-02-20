using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Target.Commands;
using Dama.Fin.Application.Budgeting.Target.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class TargetsController : ApiControllerBase 
{
    public TargetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new TargetsQuery();
            var targets = await _mediator.Send(query);
            return Ok(targets);
        });
    }

    [HttpGet]
    [Route("{region}")]
    public async Task<IActionResult> Get(string region)
    {
        var currentUser = GetCurrentUser();

        return await GetActionResult(async () =>
        {
            var query = new TargetsQuery
            {
                Tenant = currentUser.Tenant,
                Region = region
            };
            var targets = await _mediator.Send(query);
            return Ok(targets);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TargetVm target)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateTargetCommand
            {
                Target = target
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TargetVm target)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditTargetCommand
            {
                Target = target
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
