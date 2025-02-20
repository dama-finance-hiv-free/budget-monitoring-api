using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.RegionRunnerPeriod.Commands;
using Dama.Fin.Application.Budgeting.RegionRunnerPeriod.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class RegionRunnerPeriodsController : ApiControllerBase 
{
    public RegionRunnerPeriodsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new RegionRunnerPeriodsQuery();
            var regionRunnerPeriods = await _mediator.Send(query);
            return Ok(regionRunnerPeriods);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RegionRunnerPeriodVm regionRunnerPeriod)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateRegionRunnerPeriodCommand
            {
                RegionRunnerPeriod = regionRunnerPeriod
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RegionRunnerPeriodVm regionRunnerPeriod)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRegionRunnerPeriodCommand
            {
                RegionRunnerPeriod = regionRunnerPeriod
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
