using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.UserBranch.Commands;
using Dama.Fin.Application.Common.UserBranch.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class UserBranchesController : ApiControllerBase 
{
    public UserBranchesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new UserBranchesQuery();
            var userBranches = await _mediator.Send(query);
            return Ok(userBranches);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserBranchDto dto)
    {
        var currentUser = GetCurrentUser();
        dto.Tenant = currentUser.Tenant;

        return await GetActionResult(async () =>
        {
            var command = new UpdateUserBranchCommand
            {
                UserBranches = dto,
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}