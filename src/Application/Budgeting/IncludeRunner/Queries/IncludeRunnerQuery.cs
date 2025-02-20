using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.IncludeRunner.Queries;

public class IncludeRunnerQuery : IRequest<IncludeRunnerVm>
{
    public string User { get; set; }
    public string Runner { get; set; }
   
}