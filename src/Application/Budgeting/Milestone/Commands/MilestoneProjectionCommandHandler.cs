using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Commands;

public class MilestoneProjectionCommandHandler : IRequestHandler<MilestoneProjectionCommand, MilestoneCommandResponse>
{
    private readonly IMilestonePersistence _milestonePersistence;
    private readonly IMapper _mapper;

    public MilestoneProjectionCommandHandler(IMilestonePersistence milestonePersistence, IMapper mapper)
    {
        _milestonePersistence = milestonePersistence;
        _mapper = mapper;
    }

    public async Task<MilestoneCommandResponse> Handle(MilestoneProjectionCommand request, CancellationToken cancellationToken)
    {
        var response = new MilestoneCommandResponse();
        var milestone = _mapper.Map<Domain.Entity.Budgeting.Milestone>(request.Milestone);

        var result = await _milestonePersistence.UpdateProjectionAsync(milestone);

        if(result.Status!= RepositoryActionStatus.Okay)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<MilestoneVm>(result.Entity);

        return response;
    }
}