using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Project.Commands;

public abstract class ProjectCommand : IRequest<ProjectCommandResponse>
{
    public ProjectVm Project { get; set; }
}