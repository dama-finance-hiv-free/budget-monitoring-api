using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Role.Queries;

public class RoleQuery : IRequest<RoleVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
}