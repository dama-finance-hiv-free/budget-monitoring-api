using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.IncludeRunner.Queries;

public class IncludeRunnersPaginationQuery : IRequest<IncludeRunnerVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}