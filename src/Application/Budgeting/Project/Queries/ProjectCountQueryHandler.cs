using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Project.Queries;

public class ProjectCountQueryHandler : RequestHandlerBase, IRequestHandler<ProjectCountQuery, int>
{
    private readonly IProjectService _projectService;

    public ProjectCountQueryHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<int> Handle(ProjectCountQuery request, CancellationToken cancellationToken) =>
        await _projectService.GetCount(true);
}