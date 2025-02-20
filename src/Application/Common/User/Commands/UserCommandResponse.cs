using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Common;

namespace Dama.Fin.Application.Common.User.Commands;

public class UserCommandResponse : BaseResponse
{
    public UserVm Data { get; set; }
}