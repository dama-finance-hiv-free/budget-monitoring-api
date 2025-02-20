using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.SurgeActivity.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class SurgeActivitiesController : ApiControllerBase 
{
    public SurgeActivitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new SurgeActivitiesQuery();
            var surgeActivities = await _mediator.Send(query);
            return Ok(surgeActivities);
        });
    }
}
