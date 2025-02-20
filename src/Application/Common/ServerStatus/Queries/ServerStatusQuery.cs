using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.ServerStatus.Queries;

public class ServerStatusQuery : IRequest<ServerStatusVm>
{
    public string Tenant { get; set; }
    public string Branch { get; set; }
}