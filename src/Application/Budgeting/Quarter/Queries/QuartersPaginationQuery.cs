using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Quarter.Queries;

public class QuartersPaginationQuery : IRequest<QuarterVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}