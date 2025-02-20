using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.UserBranch.Commands;

public abstract class UserBranchCommand : IRequest<UserBranchCommandResponse>
{
    public UserBranchDto UserBranches { get; set; }
}