using Dama.Fin.Domain.Vm.Budgeting;
using MediatR;

namespace Dama.Fin.Application.Budgeting.UserCoordination.Commands;

public abstract class UserCoordinationCommand : IRequest<UserCoordinationCommandResponse>
{
    public UserCoordinationVm UserCoordination { get; set; }
}