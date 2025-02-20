using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.ProjectSite.Commands;
using Dama.Fin.Application.Budgeting.ProjectSite.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class ProjectSitesController : ApiControllerBase 
{
    public ProjectSitesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new ProjectSitesQuery();
            var projectSites = await _mediator.Send(query);
            return Ok(projectSites);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProjectSiteVm projectSite)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateProjectSiteCommand
            {
                ProjectSite = projectSite
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ProjectSiteVm projectSite)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditProjectSiteCommand
            {
                ProjectSite = projectSite
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
