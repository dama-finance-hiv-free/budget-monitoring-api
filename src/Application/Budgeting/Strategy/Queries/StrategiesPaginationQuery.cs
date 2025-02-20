using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Strategy.Queries;

public class StrategiesPaginationQuery : IRequest<StrategyVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}