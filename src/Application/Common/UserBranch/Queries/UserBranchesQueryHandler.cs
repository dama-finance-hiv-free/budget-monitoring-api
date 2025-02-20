using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.UserBranch.Queries;

public class UserBranchesQueryHandler : RequestHandlerBase, IRequestHandler<UserBranchesQuery, UserBranchVm[]>
{
    private readonly IUserBranchService _userBranchService;

    public UserBranchesQueryHandler(IUserBranchService userBranchService)
    {
        _userBranchService = userBranchService;
    }

    public async Task<UserBranchVm[]> Handle(UserBranchesQuery request, CancellationToken cancellationToken) =>
        await _userBranchService.GetAllAsync(true);
}