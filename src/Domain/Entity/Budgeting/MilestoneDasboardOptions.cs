using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class MilestoneDasboardOptions : IIdentifiableEntity
{
    public string Site { get; set; }
    public string Runner { get; set; }
    public string User { get; set; }
    public string Tenant { get; set; }
    public string? ReportTitle { get; set; }
    public string? Region { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}