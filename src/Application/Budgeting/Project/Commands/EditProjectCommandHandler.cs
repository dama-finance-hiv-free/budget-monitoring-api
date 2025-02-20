using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Project.Commands;

public class EditProjectCommandHandler : IRequestHandler<EditProjectCommand, ProjectCommandResponse>
{
    private readonly IProjectPersistence _projectPersistence;
    private readonly IMapper _mapper;

    public EditProjectCommandHandler(IProjectPersistence projectPersistence, IMapper mapper)
    {
        _projectPersistence = projectPersistence;
        _mapper = mapper;
    }

    public async Task<ProjectCommandResponse> Handle(EditProjectCommand request, CancellationToken cancellationToken)
    {
        var response = new ProjectCommandResponse();
        var project = _mapper.Map<Domain.Entity.Budgeting.Project>(request.Project);

        var result = await _projectPersistence.EditAsync(project);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<ProjectVm>(result.Entity);

        return response;
    }
}