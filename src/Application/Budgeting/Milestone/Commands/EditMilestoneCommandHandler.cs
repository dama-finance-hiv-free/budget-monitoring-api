using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.Milestone.Commands;

public class EditMilestoneCommandHandler : IRequestHandler<EditMilestoneCommand, MilestoneCommandResponse>
{
    private readonly IMilestonePersistence _miletstonePersistence;
    private readonly IMapper _mapper;

    public EditMilestoneCommandHandler(IMilestonePersistence miletstonePersistence, IMapper mapper)
    {
        _miletstonePersistence = miletstonePersistence;
        _mapper = mapper;
    }

    public async Task<MilestoneCommandResponse> Handle(EditMilestoneCommand request, CancellationToken cancellationToken)
    {
        var response = new MilestoneCommandResponse();
        var milestone = _mapper.Map<Domain.Entity.Budgeting.Milestone>(request.Milestone);

        var result = await _miletstonePersistence.EditAsync(milestone);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;

            return response;
        }

        response.Data = _mapper.Map<MilestoneVm>(result.Entity);

        return response;
    }
}