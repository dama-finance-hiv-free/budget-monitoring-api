using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.AnnualTarget.Queries;

public class AnnualTargetQuery : IRequest<AnnualTargetVm>
{
    public string Tenant { get; set; }
    public string Outlay { get; set; }
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string Component { get; set; }
    public string Region { get; set; }
    public double AnnualTarget { get; set; }
    public DateTime CreatedOn { get; set; }
}