using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Component.Commands;
using Dama.Fin.Application.Budgeting.Component.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class ComponentsController : ApiControllerBase 
{
    public ComponentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new ComponentsQuery();
            var components = await _mediator.Send(query);
            return Ok(components);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ComponentVm component)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateComponentCommand
            {
                Component = component
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ComponentVm component)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditComponentCommand
            {
                Component = component
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }
}
