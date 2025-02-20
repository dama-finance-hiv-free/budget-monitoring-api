using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.Role.Commands;
using Dama.Fin.Application.Common.Role.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class RolesController : ApiControllerBase 
{
    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new RolesQuery();
            var roles = await _mediator.Send(query);
            return Ok(roles);
        });
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        return await GetActionResult(async () =>
        {
            var query = new RoleQuery
            {
                Code = code
            };
            var role = await _mediator.Send(query);
            return Ok(role);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RoleVm role)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateRoleCommand
            {
                Role = role
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RoleVm role)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRoleCommand
            {
                Role = role
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}