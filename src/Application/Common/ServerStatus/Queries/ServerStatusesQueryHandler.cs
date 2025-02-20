using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Domain.Vm.Common;
using MediatR;

namespace Dama.Fin.Application.Common.ServerStatus.Queries;

public class ServerStatusesQueryHandler : RequestHandlerBase, IRequestHandler<ServerStatusesQuery, ServerStatusVm[]>
{
    private readonly IServerStatusService _serverStatusService;

    public ServerStatusesQueryHandler(IServerStatusService serverStatusService)
    {
        _serverStatusService = serverStatusService;
    }

    public async Task<ServerStatusVm[]> Handle(ServerStatusesQuery request, CancellationToken cancellationToken) => 
        await _serverStatusService.GetAllAsync(true);
}