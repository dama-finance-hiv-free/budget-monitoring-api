using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RegionRunnerPeriod.Queries;

public class RegionRunnerPeriodsPaginationQuery : IRequest<RegionRunnerPeriodVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}