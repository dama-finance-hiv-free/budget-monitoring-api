using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.UserMenu.Commands;
using Dama.Fin.Application.Common.UserMenu.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class UserRolesController : ApiControllerBase 
{
    public UserRolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new UserRolesQuery();
            var userRoles = await _mediator.Send(query);
            return Ok(userRoles);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserRoleDto dto)
    {
        var currentUser = GetCurrentUser();
        dto.Tenant = currentUser.Tenant;

        return await GetActionResult(async () =>
        {
            var command = new UpdateUserRoleCommand
            {
                UserRoles = dto,
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    [Route("assignGroupRole")]
    public async Task<IActionResult> Update([FromBody] RoleUsersVm roleUser)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRoleUsersCommand
            {
                RoleUsers = roleUser
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }


}