using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.UserCoordination.Commands;
using Dama.Fin.Application.Budgeting.UserCoordination.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class UserCoordinationsController : ApiControllerBase 
{
    public UserCoordinationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new UserCoordinationsQuery();
            var userCoordinations = await _mediator.Send(query);
            return Ok(userCoordinations);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCoordinationVm userCoordination)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateUserCoordinationCommand
            {
                UserCoordination = userCoordination
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserCoordinationVm userCoordination)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditUserCoordinationCommand
            {
                UserCoordination = userCoordination
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
