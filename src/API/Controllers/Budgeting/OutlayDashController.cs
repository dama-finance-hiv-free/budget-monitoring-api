using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.API.Models;
using Dama.Fin.Application.Budgeting.Outlay.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class OutlayDashController : ApiControllerBase 
{
    public OutlayDashController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] OutlayDashQueryParameters parameters)
    {
        var currentUser = GetCurrentUser();

        return await GetActionResult(async () =>
        {
            var query = new OutlayDashQuery
            {
                Tenant = currentUser.Tenant,
                Region = parameters.Region
            };
            var outlayDash = await _mediator.Send(query);
            return Ok(outlayDash);
        });
    }
}
