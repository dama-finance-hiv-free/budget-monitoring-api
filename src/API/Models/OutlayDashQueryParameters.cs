using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dama.Fin.API.Models;

public class OutlayDashQueryParameters
{
    [BindRequired]
    public string Region { get; set; }
}