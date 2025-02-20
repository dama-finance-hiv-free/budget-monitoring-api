using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.RunnerComponentHistory.Commands;
using Dama.Fin.Application.Budgeting.RunnerComponentHistory.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class RunnerComponentHistoriesController : ApiControllerBase 
{
    public RunnerComponentHistoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new RunnerComponentHistoriesQuery();
            var runnerComponentHistories = await _mediator.Send(query);
            return Ok(runnerComponentHistories);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RunnerComponentHistoryVm runnerComponentHistory)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateRunnerComponentHistoryCommand
            {
                RunnerComponentHistory = runnerComponentHistory
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RunnerComponentHistoryVm runnerComponentHistory)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRunnerComponentHistoryCommand
            {
                RunnerComponentHistory = runnerComponentHistory
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
