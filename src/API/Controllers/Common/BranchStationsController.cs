using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.BranchStation.Commands;
using Dama.Fin.Application.Common.BranchStation.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class BranchStationsController : ApiControllerBase 
{
    public BranchStationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new BranchStationsQuery();
            var branchStations = await _mediator.Send(query);
            return Ok(branchStations);
        });
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        return await GetActionResult(async () =>
        {
            var query = new BranchStationQuery
            {
                Code = code
            };
            var branchStation = await _mediator.Send(query);
            return Ok(branchStation);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BranchStationVm branchStation)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateBranchStationCommand
            {
                BranchStation = branchStation
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] BranchStationVm branchStation)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditBranchStationCommand
            {
                BranchStation = branchStation
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}