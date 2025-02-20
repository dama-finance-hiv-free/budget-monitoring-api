using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.CopYearCostCategory.Commands;
using Dama.Fin.Application.Budgeting.CopYearCostCategory.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class CopYearCostCategoriesController : ApiControllerBase 
{
    public CopYearCostCategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new CopYearCostCategoriesQuery();
            var copYearCostCategories = await _mediator.Send(query);
            return Ok(copYearCostCategories);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CopYearCostCategoryVm copYearCostCategory)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateCopYearCostCategoryCommand
            {
                CopYearCostCategory = copYearCostCategory
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CopYearCostCategoryVm copYearCostCategory)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditCopYearCostCategoryCommand
            {
                CopYearCostCategory = copYearCostCategory
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
