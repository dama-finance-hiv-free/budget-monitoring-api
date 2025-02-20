using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Strategy.Commands;
using Dama.Fin.Application.Budgeting.Strategy.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class StrategiesController : ApiControllerBase 
{
    public StrategiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new StrategiesQuery();
            var strategies = await _mediator.Send(query);
            return Ok(strategies);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StrategyVm strategy)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateStrategyCommand
            {
                Strategy = strategy
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] StrategyVm strategy)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditStrategyCommand
            {
                Strategy = strategy
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
