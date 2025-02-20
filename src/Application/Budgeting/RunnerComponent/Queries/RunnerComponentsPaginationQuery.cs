using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.RunnerComponent.Queries;

public class RunnerComponentsPaginationQuery : IRequest<RunnerComponentVm[]>
{
    public int Page { get; set; }
    public int Count { get; set; }
}