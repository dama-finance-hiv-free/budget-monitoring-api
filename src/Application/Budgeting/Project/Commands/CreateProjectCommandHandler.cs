using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Project.Commands;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ProjectCommandResponse>
{
    private readonly IProjectPersistence _projectPersistence;
    private readonly IMapper _mapper;

    public CreateProjectCommandHandler(IProjectPersistence projectPersistence, IMapper mapper)
    {
        _projectPersistence = projectPersistence;
        _mapper = mapper;
    }

    public async Task<ProjectCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var response = new ProjectCommandResponse();
        var project = _mapper.Map<Domain.Entity.Budgeting.Project>(request.Project);

        var result = await _projectPersistence.AddAsync(project);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<ProjectVm>(result.Entity);

        return response;
    }
}