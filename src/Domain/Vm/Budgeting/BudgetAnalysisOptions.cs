using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Vm.Budgeting;

public class BudgetAnalysisOptions : IEntityBase
{
    public string Tenant { get; set; }
    public string Project { get; set; }
    public string CopYear { get; set; }
    public string Component { get; set; }
    public string Region { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string User { get; set; }
    public string ActivityType { get; set; }
    public string ReportType { get; set; }
    public string TranCode { get; set; }
    public string ReportTitle { get; set; }
    public bool isSurge { get; set; } = false;
}