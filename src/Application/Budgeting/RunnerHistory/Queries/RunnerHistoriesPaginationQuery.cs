using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerHistory.Queries;

public class RunnerHistoriesPaginationQuery : IRequest<RunnerHistoryVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}