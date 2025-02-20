using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.CopYearBudgetCode.Queries;

public class CopYearBudgetCodesPaginationQuery : IRequest<CopYearBudgetCodeVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}