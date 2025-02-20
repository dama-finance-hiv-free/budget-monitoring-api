using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Project.Queries;

public class ProjectsPaginationQueryHandler : RequestHandlerBase, IRequestHandler<ProjectsPaginationQuery, ProjectVm[]>
{
    private readonly IProjectService _projectService;

    public ProjectsPaginationQueryHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<ProjectVm[]> Handle(ProjectsPaginationQuery request, CancellationToken cancellationToken) =>
        await _projectService.GetAllAsync(true, request.Page, request.Count);
}
