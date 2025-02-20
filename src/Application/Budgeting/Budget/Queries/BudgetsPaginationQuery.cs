using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Budget.Queries;

public class BudgetsPaginationQuery : IRequest<BudgetVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}