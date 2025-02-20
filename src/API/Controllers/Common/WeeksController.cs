using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.Week.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class WeeksController : ApiControllerBase 
{
    public WeeksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new WeeksQuery();
            var towns = await _mediator.Send(query);
            return Ok(towns);
        });
    }

    [HttpGet]
    [Route("{copYear}")]
    public async Task<IActionResult> Get(string copYear)
    {
        var currentUser = GetCurrentUser();

        return await GetActionResult(async () =>
        {
            var query = new WeeksQuery
            {
                Tenant = currentUser.Tenant,
                Params = new WeekParams
                {
                    CopYear = copYear
                }
            };
            var weeks = await _mediator.Send(query);
            return Ok(weeks);
        });
    }

}