using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class OutlayIntervention : ITenant
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string Outlay { get; set; }
    public string Intervention { get; set; }
    public DateTime CreatedOn { get; set; }
}