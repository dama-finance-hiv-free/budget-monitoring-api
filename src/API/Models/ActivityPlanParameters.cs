using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dama.Fin.API.Models;

public class ActivityPlanParameters
{
    [BindRequired]
    public string CopYear { get; set; }
    [BindRequired]
    public string Component { get; set; }
    public string Project { get; set; }
}