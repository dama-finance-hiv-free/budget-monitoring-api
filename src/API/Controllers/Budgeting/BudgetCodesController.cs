using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.BudgetCode.Commands;
using Dama.Fin.Application.Budgeting.BudgetCode.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class BudgetCodesController : ApiControllerBase 
{
    public BudgetCodesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new BudgetCodesQuery();
            var budgetCodes = await _mediator.Send(query);
            return Ok(budgetCodes);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BudgetCodeVm budgetCode)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateBudgetCodeCommand
            {
                BudgetCode = budgetCode
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] BudgetCodeVm budgetCode)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditBudgetCodeCommand
            {
                BudgetCode = budgetCode
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}
