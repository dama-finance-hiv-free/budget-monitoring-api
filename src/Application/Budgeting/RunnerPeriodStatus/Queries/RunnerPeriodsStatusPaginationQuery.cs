using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerPeriodStatus.Queries;

public class RunnerPeriodsStatusPaginationQuery : IRequest<RunnerPeriodStatusVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}