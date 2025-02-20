using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CostCategory.Queries;

public class CostCategoriesPaginationQuery : IRequest<CostCategoryVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}