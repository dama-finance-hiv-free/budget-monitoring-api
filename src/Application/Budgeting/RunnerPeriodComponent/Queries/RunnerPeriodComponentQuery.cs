using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodComponent.Queries;

public class RunnerPeriodComponentQuery : IRequest<RunnerPeriodComponentVm>
{
    public string Tenant { get; set; }
    public string RunnerPeriod { get; set; }
    public string Project { get; set; }
    public string Component { get; set; }
    public DateTime CreatedOn { get; set; }
}