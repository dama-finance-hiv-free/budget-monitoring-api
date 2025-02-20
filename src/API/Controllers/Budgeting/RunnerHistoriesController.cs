using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.RunnerHistory.Commands;
using Dama.Fin.Application.Budgeting.RunnerHistory.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class RunnerHistoriesController : ApiControllerBase 
{
    public RunnerHistoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new RunnerHistoriesQuery();
            var runnerHistories = await _mediator.Send(query);
            return Ok(runnerHistories);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RunnerHistoryVm runnerHistory)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateRunnerHistoryCommand
            {
                RunnerHistory = runnerHistory
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RunnerHistoryVm runnerHistory)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditRunnerHistoryCommand
            {
                RunnerHistory = runnerHistory
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
