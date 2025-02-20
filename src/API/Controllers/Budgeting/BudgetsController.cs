using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Budget.Commands;
using Dama.Fin.Application.Budgeting.Budget.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class BudgetsController : ApiControllerBase 
{
    public BudgetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new BudgetsQuery();
            var budgets = await _mediator.Send(query);
            return Ok(budgets);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BudgetVm budget)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateBudgetCommand
            {
                Budget = budget
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] BudgetVm budget)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditBudgetCommand
            {
                Budget = budget
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }
}
