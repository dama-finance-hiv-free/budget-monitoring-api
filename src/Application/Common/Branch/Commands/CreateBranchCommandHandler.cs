using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Branch.Commands;

public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, BranchCommandResponse>
{
    private readonly IBranchPersistence _branchPersistence;
    private readonly IMapper _mapper;

    public CreateBranchCommandHandler(IBranchPersistence branchPersistence, IMapper mapper)
    {
        _branchPersistence = branchPersistence;
        _mapper = mapper;
    }

    public async Task<BranchCommandResponse> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var response = new BranchCommandResponse();
        var branch = _mapper.Map<Domain.Entity.Common.Branch>(_mapper);

        var result = await _branchPersistence.AddAsync(branch);

        if(result.Status!= RepositoryActionStatus.Created)
        {
            response.Success = false;
            response.Data = null; 

            return response;
        }

        response.Data = _mapper.Map<BranchVm>(result.Entity);

        return response;
    }
}