using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.AnnualTarget.Queries;

public class AnnualTargetsPaginationQuery : IRequest<AnnualTargetVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}