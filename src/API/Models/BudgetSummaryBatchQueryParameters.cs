using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dama.Fin.API.Models;

public class BudgetSummaryBatchQueryParameters
{
    [BindRequired]
    public string Project { get; set; }
    [BindRequired]
    public string Component { get; set; }
}