using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.SystemMenu.Commands;
using Dama.Fin.Application.Common.SystemMenu.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class SystemMenusController : ApiControllerBase 
{
    public SystemMenusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new SystemMenusQuery();
            var systemMenus = await _mediator.Send(query);
            return Ok(systemMenus);
        });
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        return await GetActionResult(async () =>
        {
            var query = new SystemMenuQuery
            {
                Code = code
            };
            var systemMenu = await _mediator.Send(query);
            return Ok(systemMenu);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SystemMenuVm systemMenu)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateSystemMenuCommand
            {
                SystemMenu = systemMenu
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] SystemMenuVm systemMenu)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditSystemMenuCommand
            {
                SystemMenu = systemMenu
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}