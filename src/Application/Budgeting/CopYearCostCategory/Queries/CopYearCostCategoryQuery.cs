using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearCostCategory.Queries;

public class CopYearCostCategoryQuery : IRequest<CopYearCostCategoryVm>
{
    public string Tenant { get; set; }
    public string CopYear { get; set; }
    public string Project { get; set; }
    public string CostCategory { get; set; }
}