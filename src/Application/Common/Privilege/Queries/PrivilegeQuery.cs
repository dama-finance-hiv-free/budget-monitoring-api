using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.Privilege.Queries;

public class PrivilegeQuery : IRequest<PrivilegeVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
}