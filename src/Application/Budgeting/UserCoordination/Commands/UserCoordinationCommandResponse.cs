using Dama.Core.Common.Core;
using Dama.Fin.Domain.Vm.Budgeting;

namespace Dama.Fin.Application.Budgeting.UserCoordination.Commands;

public class UserCoordinationCommandResponse : BaseResponse
{
    public UserCoordinationVm Data { get; set; }
    public UserCoordinationVm[] UserCoordinations { get; set; }
}