using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Runner.Queries;

public class RunnersPaginationQuery : IRequest<RunnerVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}