using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Intervention.Commands;
using Dama.Fin.Application.Budgeting.Intervention.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class InterventionsController : ApiControllerBase 
{
    public InterventionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new InterventionsQuery();
            var interventions = await _mediator.Send(query);
            return Ok(interventions);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] InterventionVm intervention)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateInterventionCommand
            {
                Intervention = intervention
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] InterventionVm intervention)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditInterventionCommand
            {
                Intervention = intervention
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
