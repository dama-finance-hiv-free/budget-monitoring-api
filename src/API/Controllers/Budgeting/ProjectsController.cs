using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Project.Commands;
using Dama.Fin.Application.Budgeting.Project.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class ProjectsController : ApiControllerBase 
{
    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new ProjectsQuery();
            var projects = await _mediator.Send(query);
            return Ok(projects);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProjectVm project)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateProjectCommand
            {
                Project = project
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ProjectVm project)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditProjectCommand
            {
                Project = project
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
