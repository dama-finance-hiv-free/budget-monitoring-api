using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.CostCategory.Commands;
using Dama.Fin.Application.Budgeting.CostCategory.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class CostCategoriesController : ApiControllerBase 
{
    public CostCategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new CostCategoriesQuery();
            var costcategories = await _mediator.Send(query);
            return Ok(costcategories);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CostCategoryVm costCategory)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateCostCategoryCommand
            {
                CostCategory = costCategory
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CostCategoryVm costCategory)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditCostCategoryCommand
            {
                CostCategory = costCategory
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }
}
