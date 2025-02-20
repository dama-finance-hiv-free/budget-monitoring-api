using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Region.Commands;
using Dama.Fin.Application.Budgeting.Region.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class RegionsController : ApiControllerBase 
{
    public RegionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {


            var currentUser= GetCurrentUser();
            var query = new RegionsQuery();
            var regions = await _mediator.Send(query);
            return Ok(regions);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RegionVm region)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateRegionCommand
            {
                Region = region
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RegionVm region)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRegionCommand
            {
                Region = region
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
