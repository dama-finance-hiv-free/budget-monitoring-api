using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivityHistoryBatchQuery : IRequest<ActivityVm[]>
{
    public string BatchCode { get; set; }
}