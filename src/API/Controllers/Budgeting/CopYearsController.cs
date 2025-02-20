using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.CopYear.Commands;
using Dama.Fin.Application.Budgeting.CopYear.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class CopYearsController : ApiControllerBase 
{
    public CopYearsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new CopYearsQuery();
            var copYears = await _mediator.Send(query);
            return Ok(copYears);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CopYearVm copYear)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateCopYearCommand
            {
                CopYear = copYear
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CopYearVm copYear)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditCopYearCommand
            {
                CopYear = copYear
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}
