using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ProjectSite.Queries;

public class ProjectSitesQueryHandler : RequestHandlerBase, IRequestHandler<ProjectSitesQuery, ProjectSiteVm[]>
{
    private readonly IProjectSiteService _projectSiteService;

    public ProjectSitesQueryHandler(IProjectSiteService projectSiteService)
    {
        _projectSiteService = projectSiteService;
    }

    public async Task<ProjectSiteVm[]> Handle(ProjectSitesQuery request, CancellationToken cancellationToken) => 
        await _projectSiteService.GetAllAsync(true);
}
