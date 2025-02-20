using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Runner.Queries;

public class RunnersQuery : IRequest<RunnerVm[]>
{
    public string Tenant { get; set; }
}
