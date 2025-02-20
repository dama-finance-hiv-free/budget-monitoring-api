using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.Outlay.Commands;
using Dama.Fin.Application.Budgeting.Outlay.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class OutlaysController : ApiControllerBase 
{
    public OutlaysController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new OutlaysQuery();
            var outlays = await _mediator.Send(query);
            return Ok(outlays);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OutlayVm outlay)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateOutlayCommand
            {
                Outlay = outlay
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] OutlayVm outlay)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditOutlayCommand
            {
                Outlay = outlay
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [Route("costCategory")]
    public async Task<IActionResult> GetOutlayCostCategories(OutlayOption option)
    {
        return await GetActionResult(async () =>
        {
            var outlayCostCategories = await _mediator.Send(new OutlayCostCategoryQuery()
            {
                Options = option
            });
            return Ok(outlayCostCategories);
        });

    }

    //[HttpPost]
    //[Route("intervention")]
    //public async Task<IActionResult> GetOutlayInterventions(OutlayOption options)
    //{
    //    return await GetActionResult(async () =>
    //    {
    //        var outlayInterventions = await _mediator.Send(new OutlayInterventionsQuery()
    //        {
    //            Options = options
    //        });
    //        return Ok(outlayInterventions);
    //    });
    //}

}
