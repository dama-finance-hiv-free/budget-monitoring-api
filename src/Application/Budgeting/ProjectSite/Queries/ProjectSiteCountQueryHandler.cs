using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ProjectSite.Queries;

public class ProjectSiteCountQueryHandler : RequestHandlerBase, IRequestHandler<ProjectSiteCountQuery, int>
{
    private readonly IProjectSiteService _projectSiteService;

    public ProjectSiteCountQueryHandler(IProjectSiteService projectSiteService)
    {
        _projectSiteService = projectSiteService;
    }
    public async Task<int> Handle(ProjectSiteCountQuery request, CancellationToken cancellationToken) =>
        await _projectSiteService.GetCount(true);
}