using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dama.Fin.API.Models;

public class ActivityHistorySummaryParameters
{
    [BindRequired]
    public string Tenant { get; set; }

    [BindRequired]
    public string CopYear { get; set; }

    [BindRequired]
    public string Project { get; set; }

    [BindRequired]
    public string Component { get; set; }

    [BindRequired]
    public string Runner { get; set; }
}