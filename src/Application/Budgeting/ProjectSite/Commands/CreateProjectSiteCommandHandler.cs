using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.ProjectSite.Commands;

public class CreateProjectSiteCommandHandler : IRequestHandler<CreateProjectSiteCommand, ProjectSiteCommandResponse>
{
    private readonly IProjectSitePersistence _projectSitePersistence;
    private readonly IMapper _mapper;

    public CreateProjectSiteCommandHandler(IProjectSitePersistence projectSitePersistence, IMapper mapper)
    {
        _projectSitePersistence = projectSitePersistence;
        _mapper = mapper;
    }

    public async Task<ProjectSiteCommandResponse> Handle(CreateProjectSiteCommand request, CancellationToken cancellationToken)
    {
        var response = new ProjectSiteCommandResponse();
        var projectSite = _mapper.Map<Domain.Entity.Budgeting.ProjectSite>(request.ProjectSite);

        var result = await _projectSitePersistence.AddAsync(projectSite);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<ProjectSiteVm>(result.Entity);

        return response;
    }
}