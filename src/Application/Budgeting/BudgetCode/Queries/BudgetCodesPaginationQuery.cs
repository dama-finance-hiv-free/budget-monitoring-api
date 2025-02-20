using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.BudgetCode.Queries;

public class BudgetCodesPaginationQuery : IRequest<BudgetCodeVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}