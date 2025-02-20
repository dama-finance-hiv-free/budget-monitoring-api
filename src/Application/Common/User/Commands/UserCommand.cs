using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.User.Commands;

public abstract class UserCommand : IRequest<UserCommandResponse>
{
    public UserVm User { get; set; }
}