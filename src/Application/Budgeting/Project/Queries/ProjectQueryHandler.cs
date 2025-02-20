using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Project.Queries;

public class ProjectQueryHandler : RequestHandlerBase, IRequestHandler<ProjectQuery, ProjectVm>
{
    private readonly IProjectService _projectService;

    public ProjectQueryHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<ProjectVm> Handle(ProjectQuery request, CancellationToken cancellationToken) =>
        await _projectService.GetAsync(request.Tenant, request.Code);
}