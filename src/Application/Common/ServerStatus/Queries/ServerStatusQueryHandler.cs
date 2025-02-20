using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.ServerStatus.Queries;

public class ServerStatusQueryHandler : RequestHandlerBase, IRequestHandler<ServerStatusQuery, ServerStatusVm>
{
    private readonly IServerStatusService _serverStatusService;

    public ServerStatusQueryHandler(IServerStatusService serverStatusService)
    {
        _serverStatusService = serverStatusService;
    }

    public async Task<ServerStatusVm> Handle(ServerStatusQuery request, CancellationToken cancellationToken) =>
        await _serverStatusService.GetServerStatusAsync(request.Tenant, request.Branch);

}