using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Region.Commands;

public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand, RegionCommandResponse>
{
    private readonly IRegionPersistence _projectPersistence;
    private readonly IMapper _mapper;

    public CreateRegionCommandHandler(IRegionPersistence projectPersistence, IMapper mapper)
    {
        _projectPersistence = projectPersistence;
        _mapper = mapper;
    }

    public async Task<RegionCommandResponse> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
    {
        var response = new RegionCommandResponse();
        var project = _mapper.Map<Domain.Entity.Budgeting.Region>(request.Region);

        var result = await _projectPersistence.AddAsync(project);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<RegionVm>(result.Entity);

        return response;
    }
}