using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.Branch.Commands;

public class BranchCommandResponse : BaseResponse
{
    public BranchVm Data { get; set; }
}