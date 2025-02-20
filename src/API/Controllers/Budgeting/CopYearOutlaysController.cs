using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.CopYearOutlay.Commands;
using Dama.Fin.Application.Budgeting.CopYearOutlay.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class CopYearOutlaysController : ApiControllerBase 
{
    public CopYearOutlaysController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new CopYearOutlaysQuery();
            var copYearOutlays = await _mediator.Send(query);
            return Ok(copYearOutlays);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CopYearOutlayVm copYearOutlay)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateCopYearOutlayCommand
            {
                CopYearOutlay = copYearOutlay
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CopYearOutlayVm copYearOutlay)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditCopYearOutlayCommand
            {
                CopYearOutlay = copYearOutlay
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
