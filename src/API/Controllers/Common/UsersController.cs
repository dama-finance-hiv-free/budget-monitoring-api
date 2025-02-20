using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.User.Commands;
using Dama.Fin.Application.Common.User.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class UsersController : ApiControllerBase 
{
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new UsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        });
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        return await GetActionResult(async () =>
        {
            var query = new UserQuery
            {
                Code = code
            };
            var user = await _mediator.Send(query);
            return Ok(user);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserVm user)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateUserCommand
            {
                User = user
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserVm user)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditUserCommand
            {
                User = user
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}