using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.RoleMenu.Commands;
using Dama.Fin.Application.Common.RoleMenu.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class RoleMenusController : ApiControllerBase 
{
    public RoleMenusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        var currentUser = GetCurrentUser();
        return await GetActionResult(async () =>
        {
            var query = new RoleMenuQuery
            {
                Role = code,
                Tenant = currentUser.Tenant,
            };
            var roleMenu = await _mediator.Send(query);
            return Ok(roleMenu);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RoleMenuDto dto)
    {
        var currentUser = GetCurrentUser();
        dto.Tenant = currentUser.Tenant;

        return await GetActionResult(async () =>
        {
            var command = new UpdateRoleMenuCommand
            {
                RoleMenus = dto,
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }
}