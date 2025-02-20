using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.RoleMenu.Queries;

public class RoleMenuQuery : IRequest<SystemMenuVm[]>
{
    public string Tenant { get; set; }
    public string Role { get; set; }
}