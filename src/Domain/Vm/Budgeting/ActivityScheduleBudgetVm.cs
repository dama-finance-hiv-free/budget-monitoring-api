using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class ActivityScheduleBudgetVm : IEntityBase
{
    public string Tenant { get; set; }
    public string Code { get; set; }
    public string Site { get; set; }
    public string Activity { get; set; }
    public double WeekOne { get; set; }
    public double WeekTwo { get; set; }
    public double WeekThree { get; set; }
    public double WeekFour { get; set; }
    public double WeekFive { get; set; }
    public string Project { get; set; }
}