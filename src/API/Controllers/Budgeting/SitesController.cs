using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.API.Models;
using Dama.Fin.Application.Budgeting.Site.Commands;
using Dama.Fin.Application.Budgeting.Site.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class SitesController : ApiControllerBase 
{
    public SitesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get ([FromQuery] SitesQueryParameters parameters) 
    {
        var currentUser = GetCurrentUser();

        return await GetActionResult(async () =>
        {
            var query = new SitesQuery
            {
                Region = parameters.Region,
                Tenant = currentUser.Tenant
            };

            var sites = await _mediator.Send(query);
                return Ok(sites);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SiteVm site)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateSiteCommand
            {
                Site = site
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] SiteVm site)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditSiteCommand
            {
                Site = site
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
