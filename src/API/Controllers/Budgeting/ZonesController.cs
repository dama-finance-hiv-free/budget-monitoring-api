using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Zone.Commands;
using Dama.Fin.Application.Budgeting.Zone.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class ZonesController : ApiControllerBase 
{
    public ZonesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new ZonesQuery();
            var zones = await _mediator.Send(query);
            return Ok(zones);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ZoneVm zone)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateZoneCommand
            {
                Zone = zone
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ZoneVm zone)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditZoneCommand
            {
                Zone = zone
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
