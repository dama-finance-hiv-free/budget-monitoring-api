using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearCostCategory.Queries;

public class CopYearCostCategoriesPaginationQuery : IRequest<CopYearCostCategoryVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}