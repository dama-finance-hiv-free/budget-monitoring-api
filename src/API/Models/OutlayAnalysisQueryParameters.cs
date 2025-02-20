using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dama.Fin.API.Models;

public class OutlayAnalysisQueryParameters
{
    [BindRequired]
    public string Region { get; set; }

    [BindRequired]
    public string DashboardType { get; set; }

    [BindRequired]
    public string Component { get; set; }
}