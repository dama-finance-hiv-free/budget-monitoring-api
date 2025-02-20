using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.BranchStation.Commands;

public class CreateBranchStationCommandHandler : IRequestHandler<CreateBranchStationCommand, BranchStationCommandResponse>
{
    private readonly IBranchStationPersistence _branchStationPersistence;
    private readonly IMapper _mapper;

    public CreateBranchStationCommandHandler(IBranchStationPersistence branchStationPersistence, IMapper mapper)
    {
        _branchStationPersistence = branchStationPersistence;
        _mapper = mapper;
    }

    public async Task<BranchStationCommandResponse> Handle(CreateBranchStationCommand request, CancellationToken cancellationToken)
    {
        var response = new BranchStationCommandResponse();
        var branchStation = _mapper.Map<Domain.Entity.Common.BranchStation>(request.BranchStation);

        var result = await _branchStationPersistence.AddAsync(branchStation);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<BranchStationVm>(result.Entity);

        return response;
    }
}