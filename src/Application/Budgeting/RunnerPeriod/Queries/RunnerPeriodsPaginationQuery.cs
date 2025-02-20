using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriod.Queries;

public class RunnerPeriodsPaginationQuery : IRequest<RunnerPeriodVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}