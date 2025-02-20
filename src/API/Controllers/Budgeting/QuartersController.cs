using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Quarter.Commands;
using Dama.Fin.Application.Budgeting.Quarter.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class QuartersController : ApiControllerBase 
{
    public QuartersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new QuartersQuery();
            var quarters = await _mediator.Send(query);
            return Ok(quarters);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] QuarterVm quarter)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateQuarterCommand
            {
                Quarter = quarter
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] QuarterVm quarter)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditQuarterCommand
            {
                Quarter = quarter
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
