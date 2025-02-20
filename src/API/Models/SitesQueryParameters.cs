using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dama.Fin.API.Models;

public class SitesQueryParameters
{
    [BindRequired]
    public string Region { get; set; }
}