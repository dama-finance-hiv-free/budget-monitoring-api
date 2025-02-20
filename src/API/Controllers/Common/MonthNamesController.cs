using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.MonthName.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class MonthNamesController : ApiControllerBase 
{
    public MonthNamesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new MonthNamesQuery();
            var monthNames = await _mediator.Send(query);
            return Ok(monthNames);
        });
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        return await GetActionResult(async () =>
        {
            var query = new MonthNamesQuery
            {
                Lid = code
            };
            var monthName = await _mediator.Send(query);
            return Ok(monthName);
        });
    }
}