using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ProjectSite.Commands;

public abstract class ProjectSiteCommand : IRequest<ProjectSiteCommandResponse>
{
    public ProjectSiteVm ProjectSite { get; set; }
}