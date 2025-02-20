using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.SiteType.Commands;
using Dama.Fin.Application.Budgeting.SiteType.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class SiteTypesController : ApiControllerBase 
{
    public SiteTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new SiteTypesQuery();
            var siteTypes = await _mediator.Send(query);
            return Ok(siteTypes);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SiteTypeVm siteType)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateSiteTypeCommand
            {
                SiteType = siteType
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] SiteTypeVm siteType)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditSiteTypeCommand
            {
                SiteType = siteType
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
