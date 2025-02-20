using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Activity.Queries;

public class ActivitySummaryQuery : IRequest<ActivitySummaryVm[]>
{
    public ActivitySummaryParameters Options { get; set; }
}