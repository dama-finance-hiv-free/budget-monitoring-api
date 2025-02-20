using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dama.Fin.API.Models;

public class MilestoneDashQueryParameters
{
    [BindRequired]
    public string Region { get; set; }
    [BindRequired]
    public string Project { get; set; }
    [BindRequired]
    public string Component { get; set; }
}