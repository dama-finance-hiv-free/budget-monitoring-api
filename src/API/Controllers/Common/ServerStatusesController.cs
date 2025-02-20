using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.ServerStatus.Commands;
using Dama.Fin.Application.Common.ServerStatus.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class ServerStatusesController : ApiControllerBase 
{
    public ServerStatusesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new ServerStatusesQuery();
            var serverStatuses = await _mediator.Send(query);
            return Ok(serverStatuses);
        });
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        return await GetActionResult(async () =>
        {
            var currentUser = GetCurrentUser();
            var query = new ServerStatusQuery
            {
                Tenant = currentUser.Tenant,
                Branch = code
            };
            var serverStatus = await _mediator.Send(query);
            return Ok(serverStatus);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ServerStatusVm serverStatus)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateServerStatusCommand
            {
                ServerStatus = serverStatus
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ServerStatusVm serverStatus)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditServerStatusCommand
            {
                ServerStatus = serverStatus
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}