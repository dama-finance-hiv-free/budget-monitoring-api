using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.UserMenu.Queries;

public class UserRoleQuery : IRequest<UserRoleVm>
{
    public string Code { get; set; }
}