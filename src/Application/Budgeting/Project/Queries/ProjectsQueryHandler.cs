using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Project.Queries;

public class ProjectsQueryHandler : RequestHandlerBase, IRequestHandler<ProjectsQuery, ProjectVm[]>
{
    private readonly IProjectService _projectService;

    public ProjectsQueryHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<ProjectVm[]> Handle(ProjectsQuery request, CancellationToken cancellationToken) => 
        await _projectService.GetAllAsync(true);
}
