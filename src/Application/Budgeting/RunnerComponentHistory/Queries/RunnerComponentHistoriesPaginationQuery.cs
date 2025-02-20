using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponentHistory.Queries;

public class RunnerComponentHistoriesPaginationQuery : IRequest<RunnerComponentHistoryVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}