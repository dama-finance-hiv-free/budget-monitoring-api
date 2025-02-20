using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.Town.Commands;
using Dama.Fin.Application.Common.Town.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class TownsController : ApiControllerBase 
{
    public TownsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new TownsQuery();
            var towns = await _mediator.Send(query);
            return Ok(towns);
        });
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        return await GetActionResult(async () =>
        {
            var query = new TownQuery
            {
                Code = code
            };
            var town = await _mediator.Send(query);
            return Ok(town);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TownVm town)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateTownCommand
            {
                Town = town
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TownVm town)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditTownCommand
            {
                Town = town
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}