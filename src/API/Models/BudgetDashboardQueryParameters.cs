using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dama.Fin.API.Models;

public class BudgetDashboardQueryParameters
{
    [BindRequired]
    public string Project { get; set; }
    [BindRequired]
    public string Component { get; set; }
    [BindRequired]
    public string Period { get; set; }
    [BindRequired]
    public string Region { get; set; }
}