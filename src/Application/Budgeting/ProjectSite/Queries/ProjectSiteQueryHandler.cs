using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ProjectSite.Queries;

public class ProjectSiteQueryHandler : RequestHandlerBase, IRequestHandler<ProjectSiteQuery, ProjectSiteVm>
{
    private readonly IProjectSiteService _projectSiteService;

    public ProjectSiteQueryHandler(IProjectSiteService projectSiteService)
    {
        _projectSiteService = projectSiteService;
    }

    public async Task<ProjectSiteVm> Handle(ProjectSiteQuery request, CancellationToken cancellationToken) =>
        await _projectSiteService.GetAsync(request.Tenant, request.copYear);
}