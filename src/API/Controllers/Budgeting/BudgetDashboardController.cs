using System.Threading.Tasks;
using Dama.Fin.API.Core;
using Dama.Fin.API.Models;
using Dama.Fin.Application.Budgeting.Budget.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers.Budgeting;

public class BudgetDashboardController : ApiControllerBase 
{
    public BudgetDashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpGet]
    public async Task<IActionResult> Get ([FromQuery] BudgetDashboardQueryParameters parameters) 
    {
        return await GetActionResult(async () =>
        {
            var query = new BudgetDashboardQuery
            {
                Project = parameters.Project,
                Component = parameters.Component,
                Region = parameters.Region,
                Period = parameters.Period
            };
            var budgets = await _mediator.Send(query);
            return Ok(budgets);
        });
    }
}
