using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.CopYearBudgetCode.Commands;
using Dama.Fin.Application.Budgeting.CopYearBudgetCode.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class CopYearBudgetCodesController : ApiControllerBase 
{
    public CopYearBudgetCodesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new CopYearBudgetCodesQuery();
            var copYearBudgetCodes = await _mediator.Send(query);
            return Ok(copYearBudgetCodes);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CopYearBudgetCodeVm copYearBudgetCode)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateCopYearBudgetCodeCommand
            {
                CopYearBudgetCode = copYearBudgetCode
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CopYearBudgetCodeVm copYearBudgetCode)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditCopYearBudgetCodeCommand
            {
                CopYearBudgetCode = copYearBudgetCode
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
