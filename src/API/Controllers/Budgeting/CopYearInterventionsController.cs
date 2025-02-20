using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.CopYearIntervention.Commands;
using Dama.Fin.Application.Budgeting.CopYearIntervention.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class CopYearInterventionsController : ApiControllerBase 
{
    public CopYearInterventionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new CopYearInterventionsQuery();
            var copYearInterventions = await _mediator.Send(query);
            return Ok(copYearInterventions);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CopYearInterventionVm copYearIntervention)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateCopYearInterventionCommand
            {
                CopYearIntervention = copYearIntervention
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CopYearInterventionVm copYearIntervention)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditCopYearInterventionCommand
            {
                CopYearIntervention = copYearIntervention
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
