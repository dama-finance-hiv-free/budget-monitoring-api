using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class RunnerPeriodHistoryVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string Project { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public string CopYear { get; set; }
    public string Component { get; set; }
    public string Month { get; set; }
    public string Week { get; set; }
    public string ComponentWeek { get; set; }
    public string YearWeek { get; set; }
    public DateTime CreatedOn { get; set; }
    public string MilestoneProjection { get; set; }
}