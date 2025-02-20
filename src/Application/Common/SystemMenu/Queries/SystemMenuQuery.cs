using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.SystemMenu.Queries;

public class SystemMenuQuery : IRequest<SystemMenuVm>
{
    public string Tenant { get; set; }
    public string Code { get; set; }
}