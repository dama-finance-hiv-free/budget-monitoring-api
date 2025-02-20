using System;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Runner.Queries;

public class RunnerQuery : IRequest<RunnerVm>
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Code { get; set; }
    public string Region { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public string Component { get; set; }
    public string Month { get; set; }
    public string Week { get; set; }
    public string ComponentWeek { get; set; }
    public string YearWeek { get; set; }
    public string MilestoneProjection { get; set; }
    public DateTime CreatedOn { get; set; }
}