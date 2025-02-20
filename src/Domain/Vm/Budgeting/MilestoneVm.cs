using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class MilestoneVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Runner { get; set; }
    public string Region { get; set; }
    public string Project { get; set; }
    public string Activity { get; set; }
    public string Site { get; set; }
    public string BudgetNote { get; set; }
    public double Target { get; set; }
    public double Achievement { get; set; }
    public double Budget { get; set; }
    public DateTime CreatedOn { get; set; }
}