using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.Application.Common.DialogMessage.Commands;
using Dama.Fin.Application.Common.DialogMessage.Queries;
using Dama.Fin.Domain.Vm.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Common;

public class DialogMessagesController : ApiControllerBase 
{
    public DialogMessagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get () 
    {
        return await GetActionResult(async () =>
        {
            var query = new DialogMessagesQuery();
            var dialogMessages = await _mediator.Send(query);
            return Ok(dialogMessages);
        });
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        return await GetActionResult(async () =>
        {
            var query = new DialogMessageQuery
            {
                Code = code
            };
            var dialogMessage = await _mediator.Send(query);
            return Ok(dialogMessage);
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DialogMessageVm dialogMessage)
    {
        return await GetActionResult(async () =>
        {
            var command = new CreateDialogMessageCommand
            {
                DialogMessage = dialogMessage
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] DialogMessageVm dialogMessage)
    {
        return await GetActionResult(async () =>
        {
            var command = new EditDialogMessageCommand
            {
                DialogMessage = dialogMessage
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        });
    }

}