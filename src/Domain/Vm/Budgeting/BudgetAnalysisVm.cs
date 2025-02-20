using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class BudgetAnalysisVm : IEntityBase
{
    public string Code { get; set; }
    public string Description { get; set; }
    public string Region { get; set; }
    public string Zone { get; set; }
    //public string? Project { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public double Budgeted { get; set; }
    public double M01 { get; set; }
    public double M02 { get; set; }
    public double M03 { get; set; }
    public double M04 { get; set; }
    public double M05 { get; set; }
    public double M06 { get; set; }
    public double M07 { get; set; }
    public double M08 { get; set; }
    public double TotalExpenditure { get; set; }
    public double Balance { get; set; }
}