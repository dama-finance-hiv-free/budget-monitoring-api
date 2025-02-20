using System;
using Dama.Core.Common.Contracts;

namespace Dama.Fin.Domain.Entity.Budgeting;

public class ComponentActivity : ITenant
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Component { get; set; }
    public string Activity { get; set; }
    public DateTime CreatedOn { get; set; }
}