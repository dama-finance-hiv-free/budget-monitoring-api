using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dama.Fin.API.Models;

public class RunnerPeriodQueryParameters
{
    [BindRequired]
    public string Project { get; set; }
    [BindRequired]
    public string Region { get; set; }
    [BindRequired]
    public string CopYear { get; set; }
}