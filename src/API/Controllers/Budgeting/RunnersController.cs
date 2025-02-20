using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Runner.Commands;
using Dama.Fin.Application.Budgeting.Runner.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class RunnersController : ApiControllerBase 
{
    public RunnersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get ()
    {
        var currentUser = GetCurrentUser();

        return await GetActionResult(async () =>
        {
            var query = new RunnersQuery
            {
                Tenant = currentUser.Tenant
            };
            var runners = await _mediator.Send(query);
            return Ok(runners);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RunnerVm runner)
    {
        var currentUser = GetCurrentUser();

        return await GetActionResult(async () =>
        {
            var command = new CreateRunnerCommand
            {
                Runner = runner,
                Tenant = currentUser.Tenant
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RunnerVm runner)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRunnerCommand
            {
                Runner = runner
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPost]
    [Route("archive")]
    public async Task<IActionResult> Archive([FromBody] RunnerVm runner)
    {
        return await GetActionResult(async () =>
        {
            var command = new ArchiveRunnerCommand
            {
                Runner = runner
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
