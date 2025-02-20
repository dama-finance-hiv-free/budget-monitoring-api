using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.District.Commands;
using Dama.Fin.Application.Budgeting.District.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class DistrictsController : ApiControllerBase 
{
    public DistrictsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new DistrictsQuery();
            var districts = await _mediator.Send(query);
            return Ok(districts);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DistrictVm district)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateDistrictCommand
            {
                District = district
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] DistrictVm district)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditDistrictCommand
            {
                District = district
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
