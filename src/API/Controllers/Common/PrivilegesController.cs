using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.Privilege.Commands;
using Dama.Fin.Application.Common.Privilege.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class PrivilegesController : ApiControllerBase 
{
    public PrivilegesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new PrivilegesQuery();
            var privileges = await _mediator.Send(query);
            return Ok(privileges);
        });
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        return await GetActionResult(async () =>
        {
            var query = new PrivilegeQuery
            {
                Code = code
            };
            var privilege = await _mediator.Send(query);
            return Ok(privilege);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PrivilegeVm privilege)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreatePrivilegeCommand
            {
                Privilege = privilege
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PrivilegeVm privilege)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditPrivilegeCommand
            {
                Privilege = privilege
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}