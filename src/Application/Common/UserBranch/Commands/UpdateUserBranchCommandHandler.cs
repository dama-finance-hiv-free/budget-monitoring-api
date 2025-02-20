using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Persistence.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.UserBranch.Commands;

public class UpdateUserBranchCommandHandler : 
    IRequestHandler<UpdateUserBranchCommand, UserBranchCommandResponse>
{
    private readonly IUserBranchPersistence _userBranchPersistence;
    private readonly IMapper _mapper;

    public UpdateUserBranchCommandHandler(IBranchPersistence branchPersistence,
        IUserBranchPersistence userBranchPersistence, IMapper mapper) 
    {
        _userBranchPersistence = userBranchPersistence;
        _mapper = mapper;
    }

    public async Task<UserBranchCommandResponse> Handle(UpdateUserBranchCommand request, CancellationToken cancellationToken)
    {
        var response = new UserBranchCommandResponse();
        var dto = new UserBranchDto
        {
            Tenant = request.UserBranches.Tenant,
            User = request.UserBranches.User,
            Branches = request.UserBranches.Branches.Distinct().ToArray()
        };

        var result = await _userBranchPersistence.UpdateUserBranchesAsync(dto);

        if (result.Status != RepositoryActionStatus.Updated)
        {
            response.Success = false;
            response.Data = null;
            response.UserBranches= null;

            return response;
        }

        response.UserBranches = _mapper.Map<UserBranchVm[]>(result.Entity);

        return response;
    }
}