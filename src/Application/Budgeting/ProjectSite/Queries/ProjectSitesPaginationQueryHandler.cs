using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ProjectSite.Queries;

public class ProjectSitesPaginationQueryHandler : RequestHandlerBase, IRequestHandler<ProjectSitesPaginationQuery, ProjectSiteVm[]>
{
    private readonly IProjectSiteService _projectSiteService;

    public ProjectSitesPaginationQueryHandler(IProjectSiteService projectSiteService)
    {
        _projectSiteService = projectSiteService;
    }

    public async Task<ProjectSiteVm[]> Handle(ProjectSitesPaginationQuery request, CancellationToken cancellationToken) =>
        await _projectSiteService.GetAllAsync(true, request.Page, request.Count);
}
