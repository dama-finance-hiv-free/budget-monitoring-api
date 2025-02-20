using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.API.Models;
using Dama.Fin.Application.Budgeting.Milestone.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class MilestoneDashController : ApiControllerBase 
{
    public MilestoneDashController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] MilestoneDashQueryParameters parameters)
    {
        var currentUser = GetCurrentUser();

        return await GetActionResult(async () =>
        {
            var query = new MilestoneDashQuery
            {
                Tenant = currentUser.Tenant,
                Region = parameters.Region,
                Project = parameters.Project,
                Component = parameters.Component
            };
            var milestoneDash = await _mediator.Send(query);
            return Ok(milestoneDash);
        });
    }
}
