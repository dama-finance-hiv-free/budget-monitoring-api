using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.DateGeneration.Commands;
using Dama.Fin.Application.Common.DateGeneration.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class DateGenerationsController : ApiControllerBase 
{
    public DateGenerationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new DateGenerationsQuery();
            var dateGenerations = await _mediator.Send(query);
            return Ok(dateGenerations);
        });
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        return await GetActionResult(async () =>
        {
            var query = new DateGenerationQuery
            {
                Code = code
            };
            var dateGeneration = await _mediator.Send(query);
            return Ok(dateGeneration);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DateGenerationVm dateGeneration)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateDateGenerationCommand
            {
                DateGeneration = dateGeneration
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] DateGenerationVm dateGeneration)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditDateGenerationCommand
            {
                DateGeneration = dateGeneration
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}