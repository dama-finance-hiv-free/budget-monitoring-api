using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Budgeting.TransactionCode.Commands;
using Dama.Fin.Application.Budgeting.TransactionCode.Queries;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class TransactionCodesController : ApiControllerBase 
{
    public TransactionCodesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new TransactionCodesQuery();
            var transactionCodes = await _mediator.Send(query);
            return Ok(transactionCodes);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TransactionCodeVm transactionCode)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateTransactionCodeCommand
            {
                TransactionCode = transactionCode
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TransactionCodeVm transactionCode)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditTransactionCodeCommand
            {
                TransactionCode = transactionCode
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        });
    }

}
