using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Strategy.Queries;

public class StrategyQuery : IRequest<StrategyVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
}