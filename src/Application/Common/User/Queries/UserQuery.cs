using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.User.Queries;

public class UserQuery : IRequest<UserVm>
{
    public string Code { get; set; }
}