using System.Threading;
using System.Threading.Tasks;
using Dama.Fin.Domain.Contracts.Service.Batch;
using Dama.Fin.Domain.Vm.Batch;
using MediatR;

namespace Dama.Fin.Application.Batch.ServerStatusBatch.Queries;

public class ServerStatusBatchQueryHandler : RequestHandlerBase,
    IRequestHandler<SessionBatchQuery, SessionBatchVm>
{
    private readonly ISessionBatchService _sessionBatchService;

    public ServerStatusBatchQueryHandler(ISessionBatchService sessionBatchService)
    {
        _sessionBatchService = sessionBatchService;
    }

    public async Task<SessionBatchVm>
        Handle(SessionBatchQuery request, CancellationToken cancellationToken) =>
        await _sessionBatchService.GetServerStatusBatchAsync(request.Tenant, request.User, request.Branch, "01");
}