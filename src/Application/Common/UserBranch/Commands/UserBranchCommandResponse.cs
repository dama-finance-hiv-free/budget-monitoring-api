using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.UserBranch.Commands;

public class UserBranchCommandResponse : BaseResponse
{
    public UserBranchDto Data { get; set; }
    public UserBranchVm[] UserBranches { get; set; }
}