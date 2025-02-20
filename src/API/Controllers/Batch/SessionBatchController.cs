using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Batch.ServerStatusBatch.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Batch;

public class SessionBatchController : ApiControllerBase
{
    public SessionBatchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return await GetActionResult(async () =>
        {
            var currentUser = GetCurrentUser();

            var query = new SessionBatchQuery
            {
                Tenant = currentUser.Tenant,
                User = currentUser.Code
            };

            var batch = await _mediator.Send(query);

            batch.User = new UserInfoVm
            {
                Code = currentUser.Code,
                UsrName = currentUser.Name,
                PhotoUrl = currentUser.ImageUrl,
            };

            return Ok(batch);
        });
    }

    [HttpGet]
    [Route("{branch}")]
    public async Task<IActionResult> Get(string branch)
    {
        return await GetActionResult(async () =>
        {
            var currentUser = GetCurrentUser();

            var query = new SessionBatchQuery
            {
                Tenant = currentUser.Tenant,
                User = currentUser.Code,
                Branch = branch
            };

            var batch = await _mediator.Send(query);

            batch.User = new UserInfoVm
            {
                Code = currentUser.Code,
                UsrName = currentUser.Name,
                PhotoUrl = currentUser.ImageUrl,
            };

            return Ok(batch);
        });
    }
}